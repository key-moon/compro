// detail: https://atcoder.jp/contests/abc188/submissions/19336770
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
        checked
        {

            var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = nm[0];
            var m = nm[1];
            var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long[] minCost = Enumerable.Repeat(long.MaxValue / 4, n).ToArray();

            List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
            for (int i = 0; i < m; i++)
            {
                var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
                graph[st[0]].Add(st[1]);
            }
            long res = long.MinValue;
            for (int i = 0; i < n; i++)
            {
                res = Max(res, a[i] - minCost[i]);
                var nxtCost = Min(minCost[i], a[i]);
                foreach (var adj in graph[i])
                {
                    minCost[adj] = Min(minCost[adj], nxtCost);
                }
            }
            Console.WriteLine(res);
        }
    }
}
