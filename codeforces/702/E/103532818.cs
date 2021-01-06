// detail: https://codeforces.com/contest/702/submission/103532818
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
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = (int)nk[0];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var weight = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var doubling = new (int, long, long)[35][];
        doubling[0] = a.Zip(weight, (x, y) => (x, y, y)).ToArray();
        for (int i = 1; i < doubling.Length; i++)
        {
            doubling[i] = new (int, long, long)[n];
            for (int j = 0; j < n; j++)
            {
                var first = doubling[i - 1][j].Item1;
                var second = doubling[i - 1][first].Item1;
                var cost = 0L;
                cost += doubling[i - 1][j].Item2;
                cost += doubling[i - 1][first].Item2;
                var min = long.MaxValue;
                min = Min(min, doubling[i - 1][j].Item3);
                min = Min(min, doubling[i - 1][first].Item3);
                doubling[i][j] = (second, cost, min);
            }
        }
        for (int i = 0; i < n; i++)
        {
            var k = nk[1];
            int cur = i;
            long sumRes = 0;
            long minRes = long.MaxValue;
            for (int j = 0; j < doubling.Length; j++)
            {
                if ((k & 1) == 1)
                {
                    var (nxt, cost, min) = doubling[j][cur];
                    cur = nxt;
                    sumRes += cost;
                    minRes = Min(minRes, min);
                }
                k >>= 1;
            }
            Console.WriteLine($"{sumRes} {minRes}");
        }
    }
}