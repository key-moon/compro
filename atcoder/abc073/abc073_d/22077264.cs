// detail: https://atcoder.jp/contests/abc073/submissions/22077264
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
        var nmr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmr[0];
        var m = nmr[1];
        var r = nmr[2];

        var rs = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();

        int[][] mat = Enumerable.Repeat(0, n).Select(x => Enumerable.Repeat(int.MaxValue / 2, n).ToArray()).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var stc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var s = stc[0] - 1;
            var t = stc[1] - 1;
            var c = stc[2];
            mat[s][t] = c;
            mat[t][s] = c;
        }
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    mat[j][k] = Min(mat[j][k], mat[j][i] + mat[i][k]);
        int[][] dist = Enumerable.Repeat(0, 1 << r).Select(x => Enumerable.Repeat(int.MaxValue / 2, r).ToArray()).ToArray();
        for (int i = 0; i < r; i++) dist[1 << i][i] = 0;
        for (int b = 0; b < (1 << r); b++)
        {
            for (int prev = 0; prev < r; prev++)
            {
                if ((b >> prev & 1) == 0) continue;
                for (int nxt = 0; nxt < r; nxt++)
                {
                    if ((b >> nxt & 1) != 0) continue;
                    dist[b | (1 << nxt)][nxt] = Min(dist[b | (1 << nxt)][nxt], dist[b][prev] + mat[rs[prev]][rs[nxt]]);
                }
            }
        }
        Console.WriteLine(dist[^1].Min());
    }
}