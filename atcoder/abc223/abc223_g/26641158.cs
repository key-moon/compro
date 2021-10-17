// detail: https://atcoder.jp/contests/abc223/submissions/26641158
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
        var n = int.Parse(Console.ReadLine());
        ReRooting<Data> rerooting = new ReRooting<Data>(
            n,
            Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray(),
            new Data() { Available = 0, Unavailable = 0 },
            Data.Merge,
            (node, _) => node,
            (node, _) => Data.AddEdge(node)
        );
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            var query = rerooting.Query(i);
            if (query.Available == query.Unavailable) res++;
        }
        Console.WriteLine(res);
    }
}

struct Data
{
    public int Available;
    public int Unavailable;
    public static Data Merge(Data l, Data r)
    {
        return new Data()
        {
            Available = l.Available + r.Available,
            Unavailable = Max(
                Max(l.Available + r.Unavailable, l.Unavailable + r.Available),
                l.Unavailable + r.Unavailable
            )
        };
    }
    public static Data AddEdge(Data data)
    {
        return new Data()
        {
            Available = Max(data.Available, data.Unavailable),
            Unavailable = data.Available + 1
        };
    }
}


class ReRooting<T>
{
    public int NodeCount { get; private set; }

    public int[][] Adjacents;
    public int[][] IndexForAdjacent;
    public int[][] EdgeInds;

    T[] Res;
    public T[][] DP;

    T Identity;
    Func<T, T, T> Operate;
    Func<T, int, T> OperateNode;
    Func<T, int, T> OperateEdge;

    public ReRooting(int nodeCount, int[][] edges, T identity, Func<T, T, T> operate, Func<T, int, T> operateNode, Func<T, int, T> operateEdge)
    {
        NodeCount = nodeCount;

        Identity = identity;
        Operate = operate;
        OperateNode = operateNode;
        OperateEdge = operateEdge;

        List<int>[] adjacents = new List<int>[nodeCount];
        List<int>[] edgeInds = new List<int>[nodeCount];
        List<int>[] indexForAdjacents = new List<int>[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            adjacents[i] = new List<int>();
            edgeInds[i] = new List<int>();
            indexForAdjacents[i] = new List<int>();
        }
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            indexForAdjacents[edge[0]].Add(adjacents[edge[1]].Count);
            indexForAdjacents[edge[1]].Add(adjacents[edge[0]].Count);
            adjacents[edge[0]].Add(edge[1]);
            adjacents[edge[1]].Add(edge[0]);
            edgeInds[edge[0]].Add(i);
            edgeInds[edge[1]].Add(i);
        }

        Adjacents = new int[nodeCount][];
        IndexForAdjacent = new int[nodeCount][];
        EdgeInds = new int[nodeCount][];
        for (int i = 0; i < nodeCount; i++)
        {
            Adjacents[i] = adjacents[i].ToArray();
            IndexForAdjacent[i] = indexForAdjacents[i].ToArray();
            EdgeInds[i] = edgeInds[i].ToArray();
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
                accum = Operate(accum, OperateEdge(DP[node][j], EdgeInds[node][j]));
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
            for (int j = accumsFromTail.Length - 1; j >= 1; j--) accumsFromTail[j - 1] = Operate(OperateEdge(DP[node][j], EdgeInds[node][j]), accumsFromTail[j]);
            for (int j = 0; j < accumsFromTail.Length; j++)
            {
                DP[Adjacents[node][j]][IndexForAdjacent[node][j]] = OperateNode(Operate(accum, accumsFromTail[j]), node);
                accum = Operate(accum, OperateEdge(DP[node][j], EdgeInds[node][j]));
            }
            Res[node] = OperateNode(accum, node);
        }
        #endregion
    }
}

