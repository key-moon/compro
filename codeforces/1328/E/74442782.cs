// detail: https://codeforces.com/contest/1328/submission/74442782
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        Solve();
    }
    static void Solve() 
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }


        List<int> eulerTour = new List<int>();
        int[] depth = Enumerable.Repeat(-1, n).ToArray();
        int[] parent = Enumerable.Repeat(-1, n).ToArray();
        Stack<int> stack = new Stack<int>();
        parent[0] = 0;
        stack.Push(0);
        int[] representInd = new int[n];
        while (0 < stack.Count)
        {
            var elem = stack.Pop();
            if (depth[elem] == -1)
            {
                depth[elem] = depth[parent[elem]] + 1;
                representInd[elem] = eulerTour.Count;
                eulerTour.Add(depth[elem]);
                foreach (var item in graph[elem])
                {
                    if (item == parent[elem]) continue;
                    parent[item] = elem;
                    stack.Push(item);
                    stack.Push(elem);
                }
            }
            else
            {
                eulerTour.Add(depth[elem]);
            }
        }
        SegmentTree<int> LCA = new SegmentTree<int>(eulerTour.ToArray(), int.MaxValue, Min);
        for (int i = 0; i < m; i++)
        {
            var v = Console.ReadLine().Split().Skip(1).Select(x => int.Parse(x) - 1).ToArray();
            var maxNode = 0;
            var maxDepth = -1;
            foreach (var node in v)
            {
                if (depth[node] <= maxDepth) continue;
                maxNode = node;
                maxDepth = depth[node];
            }
            foreach (var node in v)
            {
                var min = Min(representInd[node], representInd[maxNode]);
                var max = Max(representInd[node], representInd[maxNode]);
                var lcaDepth = LCA.Query(min, max);
                if (depth[node] - lcaDepth > 1)
                {
                    Console.WriteLine("NO");
                    goto end;
                } 
            }
            Console.WriteLine("YES");
            end:;
        }
    }
}


class SegmentTree<T>
{
    public int Size { get; private set; }
    T Identity;
    T[] Data;
    Func<T, T, T> Merge;
    int LeafCount;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Init(size, identity, merge);
        for (int i = 1; i < Data.Length; i++) Data[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(T[] elems, T identity, Func<T, T, T> merge)
    {
        Init(elems.Length, identity, merge);
        elems.CopyTo(Data, LeafCount);
        for (int i = elems.Length + LeafCount; i < Data.Length; i++) Data[i] = identity;
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Init(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;
        Data = new T[LeafCount << 1];
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Data[LeafCount + index]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Update(index, value); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int i, T x) { Data[i += LeafCount] = x; while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { Data[i += LeafCount] = Merge(Data[i], x); while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int l, int r)
    {
        T lRes = Identity, rRes = Identity;
        for (l += LeafCount, r += LeafCount; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) lRes = Merge(lRes, Data[l]); if ((r & 1) == 0) rRes = Merge(Data[r], rRes);
        }
        return Merge(lRes, rRes);
    }
}
