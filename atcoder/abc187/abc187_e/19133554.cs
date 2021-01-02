// detail: https://atcoder.jp/contests/abc187/submissions/19133554
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
        int n = int.Parse(Console.ReadLine());

        var edges = Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = edges[0];
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        long[] sums = new long[n];
        Dictionary<int, long>[] dics = Enumerable.Repeat(0, n).Select(_ => new Dictionary<int, long>()).ToArray();
        int q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var tex = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var ind = tex[1] - 1;
            var (node, par) = tex[0] == 1 ? (edges[ind][0], edges[ind][1]) : (edges[ind][1], edges[ind][0]);
            var x = tex[2];
            if (!dics[node].ContainsKey(par)) dics[node][par] = 0;
            sums[node] += x;
            dics[node][par] += x;
        }

        ReRooting<long> rerooting = new ReRooting<long>(n, edges, 0, (x, y) => x + y, (val, node, par) => val + sums[node] - (dics[node].ContainsKey(par) ? dics[node][par] : 0));

        for (int i = 0; i < n; i++) Console.WriteLine(rerooting.Query(i));
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
    Func<T, int, int, T> OperateNode;

    public ReRooting(int nodeCount, int[][] edges, T identity, Func<T, T, T> operate, Func<T, int, int, T> operateNode)
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
        else if (NodeCount == 1) Res[0] = OperateNode(Identity, 0, -1);
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
            DP[parent][IndexForAdjacent[node][parentIndex]] = OperateNode(accum, node, parent);
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
                DP[Adjacents[node][j]][IndexForAdjacent[node][j]] = OperateNode(Operate(accum, accumsFromTail[j]), node, Adjacents[node][j]);
                accum = Operate(accum, DP[node][j]);
            }
            Res[node] = OperateNode(accum, node, -1);
        }
        #endregion
    }
}
