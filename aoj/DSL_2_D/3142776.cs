// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_D/judge/3142776/C#
using System;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nq[0];
        int q = nq[1];
        List<int> res = new List<int>();
        LazySegmentTree<int,int> ruq = new LazySegmentTree<int, int>(n, int.MaxValue, -1, (x, y) => (y == -1 ? x : y), (x) => (x == -1 ? int.MaxValue : x));
        for (int i = 0; i < q; i++)
        {
            
            int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (query[0] == 0)
            {
                ruq.Update(query[1], query[2], query[3]);
            }
            else
            {
                res.Add(ruq.Query(query[1]));
            }
        }
        Console.WriteLine(string.Join("\n", res));
    }
}

/// <summary>遅延セグ木</summary>
/// <typeparam name="T">要素の型</typeparam>
/// <typeparam name="E">作用素の型</typeparam>
class LazySegmentTree<T, E> where T : struct where E : struct
{
    /// <summary>区間2つをマージする関数を提供</summary>
    /// <returns>マージ結果</returns>
    public delegate T MergeElement(T a, T b);
    /// <summary>単位元に対して作用素を作用させる</summary>
    /// <returns>作用結果</returns>
    public delegate T Operate(E b);
    /// <summary>作用素をマージする(可換/交換法則を満たす必要がある)</summary>
    /// <returns>マージ結果</returns>
    public delegate E MergeOperator(E a, E b);

    public int length { get; }

    MergeElement mergeElement = null;
    Operate operate;
    MergeOperator mergeOperator;
    /// <summary>作用素の単位元(初期化時に撒く)</summary>
    T ValueIdentityElement;
    /// <summary>作用素の単位元(初期化時に撒く)</summary>
    E OperatorIdentityElement;
    /// <summary>ノードの作用素</summary>
    private E[] nodesOp;
    /// <summary>未作用の作用素</summary>
    private E[] operators;
    /// <summary>伝搬するべきか</summary>
    private bool[] isRemained;

    /// <summary>コンストラクタ</summary>
    /// <param name="length">長さ</param>
    /// <param name="operatorIdentityElement">作用素の単位元</param>
    /// <param name="operate">作用素を作用させる関数</param>
    /// <param name="mergeOperator">作用素をマージする関数</param>
    public LazySegmentTree(int length,T valueIdentityElement, E operatorIdentityElement, MergeOperator mergeOperator, Operate operate)
    {
        length--;
        this.length = 1;
        this.mergeOperator = mergeOperator;
        this.operate = operate;
        while (length != 0)
        {
            length >>= 1;
            this.length <<= 1;
        }
        ValueIdentityElement = valueIdentityElement;
        OperatorIdentityElement = operatorIdentityElement;
        nodesOp = Enumerable.Repeat(OperatorIdentityElement, this.length << 1).ToArray();
        operators = Enumerable.Repeat(OperatorIdentityElement, this.length << 1).ToArray();
        isRemained = Enumerable.Repeat(false, this.length << 1).ToArray();
    }

    /// <summary>コンストラクタ</summary>
    /// <param name="length">長さ</param>
    /// <param name="elementIdentityElement">各要素の単位元</param>
    /// <param name="operatorIdentityElement">作用素の単位元</param>
    /// <param name="operate">作用素を作用させる関数</param>
    /// <param name="mergeOperator">作用素をマージする関数</param>
    public LazySegmentTree(int length, T valueIdentityElement, E operatorIdentityElement, MergeElement mergeElement, MergeOperator mergeOperator, Operate operate) : this(length, valueIdentityElement, operatorIdentityElement, mergeOperator, operate)
    {
        this.mergeElement = mergeElement;
    }

    /// <summary>インデクサで要素にアクセス</summary>
    public T this[int index]
    {
        get { return Query(index); }
    }

    public void Update(int ind,E op)
    {
        int leafInd = GetIndOfLeafNode(ind);
        nodeEval(leafInd);
        operateNode(leafInd, op);
    }

    /// <summary>s-e区間にopを作用</summary>
    public void Update(int s, int e, E op)
    {
        if (s > e)
        {
            Update(e, s, op);
            return;
        }
        List<int> Sindexes, Eindexes;
        sectionEval(s, e, out Sindexes, out Eindexes);
        if (Sindexes.Count != 0) nodeEval(Sindexes[0]);
        foreach (var section in Sindexes)
        {
            operateNode(section, op);
        }
        if (Eindexes.Count != 0) nodeEval(Eindexes[0]);
        foreach (var section in Eindexes)
        {
            operateNode(section, op);
        }
    }

    /// <summary>点クエリ</summary>
    public T Query(int index)
    {
        int leafInd = GetIndOfLeafNode(index);
        nodeEval(leafInd);
        return operate(nodesOp[leafInd]);
    }

    /// <summary>区間クエリ</summary>
    public T Query(int s, int e)
    {
        if (s > e) Query(e, s);
        List<int> Sindexes, Eindexes;
        sectionEval(s, e, out Sindexes, out Eindexes);

        T resS = ValueIdentityElement;
        T resE = ValueIdentityElement;

        foreach (var section in Sindexes) resS = mergeElement(resS, operate(nodesOp[section]));
        foreach (var section in Eindexes) resE = mergeElement(operate(nodesOp[section]), resE);

        return mergeElement(resS, resE);
    }

    /// <summary>区間の遅延評価</summary>
    private void sectionEval(int s, int e, out List<int> Sindexes, out List<int> Eindexes)
    {
        if (s > e)
        {
            sectionEval(e, s, out Sindexes, out Eindexes);
            return;
        }

        int xor = (s ^ e);
        int sectionLength = 1;
        while (xor != 0)
        {
            sectionLength <<= 1;
            xor >>= 1;
        }

        int sectionBegin = s & (int.MaxValue - (sectionLength - 1));
        int sectionEnd = s & (sectionLength - 1);
        int sectionMiddle = (sectionBegin == s) ? sectionBegin :
                             ((sectionEnd == e) ? sectionEnd :
                                                  sectionBegin + (sectionLength >> 1));

        int leafS = GetIndOfLeafNode(s);
        int leafE = GetIndOfLeafNode(e);

        int sDiff = sectionMiddle - s;
        int eDiff = e - sectionMiddle + 1;
        Sindexes = new List<int>();
        Eindexes = new List<int>();
        
        for (int i = 1; i <= sectionLength; i <<= 1)
        {
            if ((sDiff & i) == i)
            {
                nodeEval(leafS);
                Sindexes.Add(leafS);
                leafS++;
            }
            leafS >>= 1;
            if ((eDiff & i) == i)
            {
                nodeEval(leafE);
                Eindexes.Add(leafE);
                leafE--;
            }
            leafE >>= 1;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    /// <summary>ノードの遅延評価</summary>
    private void nodeEval(int index)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(index);
        while (index >= 1)
        {
            stack.Push(index);
            index >>= 1;
        }
        while (stack.Count != 0)
        {
            int ind = stack.Pop();
            if (!isRemained[ind]) continue;
            isRemained[ind] = false;
            var op = operators[ind];
            nodesOp[ind] = mergeOperator(nodesOp[ind], op);
            if (ind < length)
            {
                ind <<= 1;
                operateNode(ind, op);
                ind++;
                operateNode(ind, op);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    /// <summary>ノードに対して作用素を作用させるだけ</summary>
    private void operateNode(int ind, E op)
    {
        if (!isRemained[ind])
        {
            operators[ind] = op;
            isRemained[ind] = true;
        }
        else
        {
            operators[ind] = mergeOperator(operators[ind], op);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    /// <summary>葉ノード(最下位ノード)のnodes内indexを取得</summary>
    private int GetIndOfLeafNode(int index) => index + length;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    /// <summary>indexが範囲内かを調べる</summary>
    private void AssertIndex(int index) { if (index >= length) throw new IndexOutOfRangeException(); }
}
