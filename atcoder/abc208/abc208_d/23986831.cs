// detail: https://atcoder.jp/contests/abc208/submissions/23986831
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
        List<(int, int)>[] g = Enumerable.Repeat(0, n).Select(_ => new List<(int, int)>()).ToArray();
        List<(int, int)>[] revG = Enumerable.Repeat(0, n).Select(_ => new List<(int, int)>()).ToArray();

        var MAX = int.MaxValue / 2;
        int[][] directDists = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(MAX, n).ToArray()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var stc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var s = stc[0] - 1;
            var t = stc[1] - 1;
            var c = stc[2];
            g[s].Add((t, c));
            revG[t].Add((s, c));
            directDists[s][t] = Min(directDists[s][t], c);
        }

        int[][] dists = Enumerable.Repeat(0, n).Select(_ => Enumerable.Repeat(MAX, n).ToArray()).ToArray();
        for (int i = 0; i < n; i++) dists[i][i] = 0;

        long res = 0;
        for (int k = 0; k < n; k++)
        {
            foreach (var (j, c) in g[k]) dists[k][j] = Min(dists[k][j], c);
            foreach (var (j, c) in revG[k]) dists[j][k] = Min(dists[j][k], c);
            for (int s = 0; s < n; s++)
                for (int t = 0; t < n; t++)
                    dists[s][t] = Min(dists[s][t], dists[s][k] + dists[k][t]);
            for (int s = 0; s < n; s++)
                for (int t = 0; t < n; t++)
                {
                    var d = Min(directDists[s][t], dists[s][t]);
                    if (d < MAX) res += d;
                }
        }
        Console.WriteLine(res);
    }
}
