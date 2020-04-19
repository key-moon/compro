// detail: https://atcoder.jp/contests/abc163/submissions/12136578
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


public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var color = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        int[] subTreeSize = new int[n];
        int getSubTreeSize(int node, int parent)
        {
            foreach (var item in graph[node])
            {
                if (item == parent) continue;
                subTreeSize[node] += getSubTreeSize(item, node);
            }
            return ++subTreeSize[node];
        }
        getSubTreeSize(0, -1);

        long[] res = new long[n];
        State[] states = Enumerable.Range(0, n).Select(x => new State() { Color = x, Size = n }).ToArray();
        void dfs(int node, int parent)
        {
            var forRootChunkSize = states[color[node]].Size - subTreeSize[node];
            foreach (var item in graph[node])
            {
                if (item == parent) continue;
                states[color[node]].Size = subTreeSize[item];
                dfs(item, node);
                res[color[node]] += states[color[node]].Size * (states[color[node]].Size - 1) / 2 + states[color[node]].Size;
            }
            states[color[node]].Size = forRootChunkSize;
        }
        dfs(0, -1);
        foreach (var state in states)
        {
            res[state.Color] += state.Size * (state.Size - 1) / 2 + state.Size;
        }
        long total = (long)n * (n - 1) / 2 + n;
        Console.WriteLine(string.Join("\n", res.Select(x => total - x)));
    }
}

class State
{
    public int Color;
    public long Size;
}

