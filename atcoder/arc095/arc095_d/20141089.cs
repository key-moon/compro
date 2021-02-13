// detail: https://atcoder.jp/contests/arc095/submissions/20141089
using System;
using System.Collections.Immutable;
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
        int n = int.Parse(Console.ReadLine());
        var edges = Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        ReRooting<int> rerooting = new ReRooting<int>(n, edges, 0, Max, (x, _) => x + 1);
        var rerootingRes = Enumerable.Range(0, n).Select(rerooting.Query).ToArray();
        var max = rerootingRes.Max();
        var maxInd = Array.IndexOf(rerootingRes, max);

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        foreach (var st in edges)
        {
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        Stack<(ImmutableStack<int>, int)> stack = new Stack<(ImmutableStack<int>, int)>();
        stack.Push((new ImmutableStack<int>().Push(maxInd), -1));
        var maxSeq = new ImmutableStack<int>();
        while (stack.Count != 0)
        {
            var (seq, prev) = stack.Pop();
            if (maxSeq.Count < seq.Count) maxSeq = seq;
            var node = seq.Top;
            foreach (var adj in graph[node])
            {
                if (adj == prev) continue;
                stack.Push((seq.Push(adj), node));
            }
        }

        List<int> stem = new List<int>();
        while (maxSeq.Count != 0)
        {
            stem.Add(maxSeq.Top);
            maxSeq = maxSeq.Pop();
        }
        var dic = stem.ToDictionary(x => x, x => 0);
        for (int i = 0; i < n; i++)
        {
            if (dic.ContainsKey(i)) continue;
            var parent = graph[i].First();
            if (graph[i].Count != 1 || !dic.ContainsKey(parent))
            {
                Console.WriteLine(-1);
                return;
            }
            dic[parent]++;
        }
        for (int i = 0; i < stem.Count; i++)
        {
            if (dic[stem[i]] < dic[stem[^(i + 1)]]) break;
            if (dic[stem[i]] > dic[stem[^(i + 1)]])
            {
                stem.Reverse();
                break;
            }
        }

        List<int> res = new List<int>();
        foreach (var node in stem)
        {
            var cnt = res.Count;
            res.AddRange(Enumerable.Range(cnt + 1, dic[node]));
            res.Add(cnt);
        }
        Console.WriteLine(string.Join(" ", res.Select(x => x + 1)));
    }
}

class ReRooting<T>
{
    public int NodeCount { get; private set; }

    int[][] Adjacents;
    int[][] IndexForAdjacent;

    T[] Res;
    T[][] DP;

    T Identity;
    Func<T, T, T> Operate;
    Func<T, int, T> OperateNode;

    public ReRooting(int nodeCount, int[][] edges, T identity, Func<T, T, T> operate, Func<T, int, T> operateNode)
    {
        NodeCount = nodeCount;

        Identity = identity;
        Operate = operate;
        OperateNode = operateNode;

        List<int>[] adjacents = new List<int>[nodeCount];
        List<int>[] indexForAdjacents = new List<int>[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            adjacents[i] = new List<int>();
            indexForAdjacents[i] = new List<int>();
        }
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            indexForAdjacents[edge[0]].Add(adjacents[edge[1]].Count);
            indexForAdjacents[edge[1]].Add(adjacents[edge[0]].Count);
            adjacents[edge[0]].Add(edge[1]);
            adjacents[edge[1]].Add(edge[0]);
        }

        Adjacents = new int[nodeCount][];
        IndexForAdjacent = new int[nodeCount][];
        for (int i = 0; i < nodeCount; i++)
        {
            Adjacents[i] = adjacents[i].ToArray();
            IndexForAdjacent[i] = indexForAdjacents[i].ToArray();
        }

        DP = new T[Adjacents.Length][];
        Res = new T[Adjacents.Length];

        for (int i = 0; i < Adjacents.Length; i++) DP[i] = new T[Adjacents[i].Length];
        if (NodeCount > 1) Initialize();
        else if (NodeCount == 1) Res[0] = OperateNode(Identity, 0);
    }

    public T Query(int node) => Res[node];

    private void Initialize()
    {
        int[] parents = new int[NodeCount];
        int[] order = new int[NodeCount];

        #region InitOrderedTree
        var index = 0;
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        parents[0] = -1;
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            order[index++] = node;
            for (int i = 0; i < Adjacents[node].Length; i++)
            {
                var adjacent = Adjacents[node][i];
                if (adjacent == parents[node]) continue;
                stack.Push(adjacent);
                parents[adjacent] = node;
            }
        }
        #endregion

        #region fromLeaf
        for (int i = order.Length - 1; i >= 1; i--)
        {
            var node = order[i];
            var parent = parents[node];

            T accum = Identity;
            int parentIndex = -1;
            for (int j = 0; j < Adjacents[node].Length; j++)
            {
                if (Adjacents[node][j] == parent)
                {
                    parentIndex = j;
                    continue;
                }
                accum = Operate(accum, DP[node][j]);
            }
            DP[parent][IndexForAdjacent[node][parentIndex]] = OperateNode(accum, node);
        }
        #endregion

        #region toLeaf
        for (int i = 0; i < order.Length; i++)
        {
            var node = order[i];
            T accum = Identity;
            T[] accumsFromTail = new T[Adjacents[node].Length];
            accumsFromTail[accumsFromTail.Length - 1] = Identity;
            for (int j = accumsFromTail.Length - 1; j >= 1; j--) accumsFromTail[j - 1] = Operate(DP[node][j], accumsFromTail[j]);
            for (int j = 0; j < accumsFromTail.Length; j++)
            {
                DP[Adjacents[node][j]][IndexForAdjacent[node][j]] = OperateNode(Operate(accum, accumsFromTail[j]), node);
                accum = Operate(accum, DP[node][j]);
            }
            Res[node] = OperateNode(accum, node);
        }
        #endregion
    }
}

class ImmutableStack<T>
{
    readonly ImmutableStack<T> previousStack;
    public readonly T Top;
    public readonly int Count;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack() : this(null, default, 0) { }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ImmutableStack(ImmutableStack<T> prev, T top, int count)
    {
        previousStack = prev;
        Top = top;
        Count = count;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack<T> Push(T value) => new ImmutableStack<T>(this, value, Count + 1);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableStack<T> Pop() => previousStack == null ? null : previousStack;
}
