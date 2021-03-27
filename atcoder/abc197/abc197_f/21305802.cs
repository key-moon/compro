// detail: https://atcoder.jp/contests/abc197/submissions/21305802
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        List<int>[][] graph = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(0, 26).Select(_ => new List<int>()).ToArray()).ToArray();
        List<(int, int)> edges = new List<(int, int)>();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split();
            var s = int.Parse(st[0]) - 1;
            var t = int.Parse(st[1]) - 1;
            var c = st[2][0];
            graph[s][c - 'a'].Add(t);
            graph[t][c - 'a'].Add(s);
            edges.Add((s, t));
            edges.Add((t, s));
        }
        int[][] dp = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(int.MaxValue / 2, n).ToArray()).ToArray();
        Queue<(int, int)> queue = new Queue<(int, int)>();
        dp[0][n - 1] = 0;
        queue.Enqueue((0, n - 1));
        while (queue.Count != 0)
        {
            var (s, t) = queue.Dequeue();
            var nxtval = dp[s][t] + 2;
            for (int i = 0; i < 26; i++)
            {
                foreach (var sadj in graph[s][i])
                {
                    foreach (var tadj in graph[t][i])
                    {
                        if (dp[sadj][tadj] <= nxtval) continue;
                        dp[sadj][tadj] = nxtval;
                        queue.Enqueue((sadj, tadj));
                    }
                }
            }
        }
        var res = Enumerable.Range(0, n).Min(x => dp[x][x]);
        res = Min(res, edges.Min(x => dp[x.Item1][x.Item2] + 1));
        if (int.MaxValue / 2 <= res) res = -1;
        Console.WriteLine(res);
    }
}