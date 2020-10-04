// detail: https://codeforces.com/contest/1422/submission/94667057
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var mat = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();
        var res = 0L;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                (int, int)[] inds = new[]
                {
                    (i, j),
                    (i, m - j - 1),
                    (n - i - 1, j),
                    (n - i - 1, m - j - 1)
                };
                var mid = inds.Select(x => mat[x.Item1][x.Item2]).OrderBy(x => x).ElementAt(1);
                foreach (var (y, x) in inds)
                {
                    res += Abs(mid - mat[y][x]);
                    mat[y][x] = mid;
                }
            }
        }
        Console.WriteLine(res);
    }
}