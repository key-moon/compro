// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_B/judge/3139211/C#
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
        SegmentTree<int> rsq = new SegmentTree<int>(n, 0, (x, y) => x + y);
        for (int i = 0; i < q; i++)
        {
            int[] cxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int c = cxy[0];
            int x = cxy[1];
            int y = cxy[2];
            if (c == 0)
            {
                rsq[x - 1] += y;
            }
            else
            {
                res.Add(rsq.Query(x - 1, y - 1));
            }
        }
        Console.WriteLine(string.Join("\n", res));
    }
}

/// <summary>セグ木(一点更新区間取得)</summary>
/// <example>range minimum query : new SegmentTree<int>(n, int.MaxValue, Min);</example>
/// <typeparam name="T">要素の型</typeparam>
class SegmentTree<T>
{
    /// <summary>区間2つをマージする関数を提供</summary>
    /// <returns>マージ結果</returns>
    public delegate T Merge(T a, T b);
    /// <summary></summary>
    Merge merge;
    /// <summary>単位元(初期化時に撒く)</summary>
    T IdentityElement;
    /// <summary>ノード</summary>
    public T[] nodes;
    /// <summary>最下位ノードの個数(2^nにしておく)</summary>
    int leafNodeCount;

    /// <summary>コンストラクタ</summary>
    /// <param name="length">長さ</param>
    /// <param name="identityElement">単位元(addだったら0,maxだったら-inf…)</param>
    /// <param name="merge">マージするための関数</param>
    public SegmentTree(int length, T identityElement, Merge merge)
    {
        length--;
        leafNodeCount = 1;
        this.merge = merge;
        while (length != 0)
        {
            length >>= 1;
            leafNodeCount <<= 1;
        }
        IdentityElement = identityElement;
        nodes = Enumerable.Repeat(IdentityElement, leafNodeCount << 1).ToArray();
    }

    /// <summary>Updateにインデクサでアクセス</summary>
    public T this[int index]
    {
        set { Update(index, value); }
        get { return Query(index); }
    }

    /// <summary>indexにvalueを代入(0-indexed)</summary>
    public void Update(int index, T value)
    {
        AssertIndex(index);
        int leafInd = GetIndOfLeafNode(index);
        nodes[leafInd] = value;
        while (leafInd > 1)
        {
            leafInd >>= 1;
            MergeChilds(leafInd);
        }
    }

    /// <summary>区間クエリ</summary>
    public T Query(int s, int e)
    {
        if (s > e) return Query(e, s);
        AssertIndex(s);
        AssertIndex(e);

        int xor = (s ^ e);
        int sectionLength = 1;
        while (xor != 0)
        {
            sectionLength <<= 1;
            xor >>= 1;
        }

        int sectionBegin = s & (int.MaxValue - (sectionLength - 1));
        int sectionEnd = s & (sectionLength - 1);
        int sectionMiddle;
        if (sectionBegin == s) sectionMiddle = sectionBegin;
        else if (sectionEnd == e) sectionMiddle = sectionEnd;
        else sectionMiddle = sectionBegin + (sectionLength >> 1);

        int leafS = GetIndOfLeafNode(s);
        int leafE = GetIndOfLeafNode(e);

        int sDiff = sectionMiddle - s;
        int eDiff = e - sectionMiddle + 1;

        T resS = IdentityElement;
        T resE = IdentityElement;
        for (int i = 1; i <= sectionLength; i <<= 1)
        {
            if ((sDiff & i) == i)
            {
                resS = merge(resS, nodes[leafS]);
                leafS++;
            }
            if ((eDiff & i) == i)
            {
                resE = merge(nodes[leafE], resE);
                leafE--;
            }
            leafS >>= 1;
            leafE >>= 1;
        }
        return merge(resS, resE);
    }

    public T Query(int index)
    {
        AssertIndex(index);
        return nodes[GetIndOfLeafNode(index)];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    /// <summary>子ノード2つをマージ</summary>
    /// <param name="index">マージするノードの親ノード</param>
    private void MergeChilds(int index)
    {
        int child = index << 1;
        nodes[index] = merge(nodes[child], nodes[child + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    /// <summary>葉ノード(最下位ノード)のnodes内indexを取得</summary>
    private int GetIndOfLeafNode(int index) => index + leafNodeCount;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    /// <summary>indexが範囲内かを調べる</summary>
    private void AssertIndex(int index) { if (index >= leafNodeCount) throw new IndexOutOfRangeException(); }
}
