// detail: https://codeforces.com/contest/1146/submission/53072443
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        // > -n : 上に行ってる奴は全部下に戻ってくる -n-0区間が反転
        // >  n : 
        var n = nq[0];
        var q = nq[1];
        //update:item2 == 1
        SegmentTree<int> segTree = new SegmentTree<int>(200001, 0, (x, y) => (y & 1) == 1 ? y : ((x ^ y) & 2) | (x & 1));
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < q; i++)
        {
            var query = Console.ReadLine().Split();
            int x = int.Parse(query[1]);
            if(query[0] == "<")
            {
                //0以下の時は、上が戻って下が上がるだけ
                if (x <= 0)
                {
                    segTree.Operate(0, 100000 + x - 1, 3);
                    segTree.Operate(100000 - x + 1, 200001, 1);
                }
                //0より大きい時は、上が戻って下が上がるだけ
                else
                {
                    segTree.Operate(0, 100000 - x, 3);
                    segTree.Operate(100000 + x, 200001, 1);
                    segTree.Operate(100000 - x + 1, 100000 + x - 1, 2);
                }
            }
            else
            {
                if (0 <= x)
                {
                    segTree.Operate(0, 100000 - x - 1, 1);
                    segTree.Operate(100000 + x + 1, 200001, 3);
                }
                else
                {
                    segTree.Operate(0, 100000 + x, 1);
                    segTree.Operate(100000 - x, 200001, 3);
                    segTree.Operate(100000 + x + 1, 100000 - x - 1, 2);
                }
            }
        }
        Console.WriteLine(string.Join(" ", a.Select(y => (segTree.Query(y + 100000) & 2) == 2 ? -y : y)));
    }
}


class SegmentTree<T>
{
    public int Size { get; private set; }
    T IdentityElement;
    Func<T, T, T> Merge;
    int LeafCount;
    int TreeHeight;
    T[] Datas;

    public SegmentTree(int size, T identityElement, Func<T, T, T> merge) : this(Enumerable.Repeat(identityElement, size).ToArray(), identityElement, merge) { }

    public SegmentTree(T[] elems, T identityElement, Func<T, T, T> merge)
    {
        Size = elems.Length;
        IdentityElement = identityElement;
        Merge = merge;
        LeafCount = 1;
        TreeHeight = 1;
        while (LeafCount < elems.Length)
        {
            LeafCount <<= 1;
            TreeHeight++;
        }

        Datas = Enumerable.Repeat(identityElement, LeafCount).Concat(elems).Concat(Enumerable.Repeat(identityElement, LeafCount - Size)).ToArray();
    }

    public T this[int index]
    {
        get { return Query(index); }
        set { Operate(index, index + 1, value); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if (l % 2 == 1) Datas[l] = Merge(Datas[l], x);
            if (r % 2 == 0) Datas[r] = Merge(Datas[r], x);
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if (l % 2 == 1) Datas[l] = x;
            if (r % 2 == 0) Datas[r] = x;
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int index)
    {
        index += LeafCount;
        Propagate(index);
        return Datas[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = TreeHeight - 1; i >= 1; i--) Eval(sectionIndex >> i);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Eval(int sectionIndex)
    {
        Datas[sectionIndex * 2] = Merge(Datas[sectionIndex * 2], Datas[sectionIndex]);
        Datas[sectionIndex * 2 + 1] = Merge(Datas[sectionIndex * 2 + 1], Datas[sectionIndex]);
        Datas[sectionIndex] = IdentityElement;
    }
}
