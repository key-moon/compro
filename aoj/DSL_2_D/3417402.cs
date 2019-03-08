// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/DSL_2_D/judge/3417402/C#
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

class P
{
    static void Main()
    {
        const int IDENTITY_ELEMENT = int.MinValue;

        var nq = Console.ReadLine().Split().Select(int.Parse).ToList();
        SegmentTree<int> RUQ = new SegmentTree<int>(Enumerable.Repeat(int.MaxValue, nq[0]).ToArray(), IDENTITY_ELEMENT, (x, y) => y == IDENTITY_ELEMENT ? x : y);
        for (int i = 0; i < nq[1]; i++)
        {
            int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (query[0] == 0) RUQ.Operate(query[1], query[2] + 1, query[3]);
            else Console.WriteLine(RUQ.Query(query[1]));
        }
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
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount - 1;
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

