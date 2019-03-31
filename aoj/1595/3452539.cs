// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1595/judge/3452539/C#
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        OmniTreeDP treeDP = new OmniTreeDP(n, Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray());

        var totalLength = (n - 1) * 2;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) res[i] = totalLength - treeDP.Query(i) + 1;
        Console.WriteLine(string.Join("\n", res));
    }
}

class OmniTreeDP
{
    int[][] Neighbours;
    int[][] IndexForNeighbours;

    int[][] dp;
    int[] SearchState;

    public OmniTreeDP(int nodeCount, int[][] edges)
    {
        List<int>[] neighbours = new List<int>[nodeCount];
        List<int>[] indexForNeighbours = new List<int>[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            neighbours[i] = new List<int>();
            indexForNeighbours[i] = new List<int>();
        }
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            indexForNeighbours[edge[0]].Add(neighbours[edge[1]].Count);
            indexForNeighbours[edge[1]].Add(neighbours[edge[0]].Count);
            neighbours[edge[0]].Add(edge[1]);
            neighbours[edge[1]].Add(edge[0]);
        }

        Neighbours = new int[nodeCount][];
        IndexForNeighbours = new int[nodeCount][];
        for (int i = 0; i < nodeCount; i++)
        {
            Neighbours[i] = neighbours[i].ToArray();
            IndexForNeighbours[i] = indexForNeighbours[i].ToArray();
        }

        dp = new int[Neighbours.Length + 1][];
        SearchState = new int[Neighbours.Length + 1];

        dp[0] = new int[Neighbours.Length];
        for (int i = 0; i < Neighbours.Length; i++)
        {
            dp[i + 1] = new int[Neighbours[i].Length];
            SearchState[i] = -2;
        }
    }

    public int Query(int x)
    {
        if (SearchState[x] != -1) DFS(x, -1, x);
        return dp[0][x];
    }

    private void DFS(int x, int parent, int xIndexForParent)
    {
        Debug.Assert(SearchState[x] != -1 && (SearchState[x] == -2 || Neighbours[x][SearchState[x]] != parent));

        int accum = 0;
        if (SearchState[x] == -2)
        {
            SearchState[x] = -1;
            for (int i = 0; i < Neighbours[x].Length; i++)
            {
                if (Neighbours[x][i] == parent)
                {
                    SearchState[x] = i;
                    continue;
                }
                var state = SearchState[Neighbours[x][i]];
                if (state != -1 && state != IndexForNeighbours[x][i]) DFS(Neighbours[x][i], x, i);
                accum = Max(accum, dp[x + 1][i]);
            }
            dp[parent + 1][xIndexForParent] = accum + 1;
            if (SearchState[x] != -1) return;
            accum = 0;
        }
        else
        {
            var targetInd = SearchState[x];
            var target = Neighbours[x][targetInd];
            var targetState = SearchState[target];
            if (targetState != -1 && targetState != IndexForNeighbours[x][targetInd]) DFS(Neighbours[x][targetInd], x, targetInd);
        }

        int[] accumsFromTail = new int[Neighbours[x].Length];
        accumsFromTail[accumsFromTail.Length - 1] = 0;
        for (int i = accumsFromTail.Length - 2; i >= 0; i--) accumsFromTail[i] = Max(accumsFromTail[i + 1], dp[x + 1][i + 1]);
        for (int i = 0; i < accumsFromTail.Length; i++)
        {
            dp[Neighbours[x][i] + 1][IndexForNeighbours[x][i]] = Max(accum, accumsFromTail[i]) + 1;
            accum = Max(accum, dp[x + 1][i]);
        }

        dp[0][x] = accum + 1;
        SearchState[x] = -1;
    }
}
