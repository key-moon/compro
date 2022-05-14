// detail: https://atcoder.jp/contests/abc251/submissions/31670446
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long Solve(long[] a)
        {
            long prev = long.MaxValue / 2;
            long res = a[0];
            foreach (var item in a.Skip(1))
            {
                var nxt = Min(prev, res) + item;
                (prev, res) = (res, nxt);
            }
            return Min(prev, res);
        }
        Console.WriteLine(Min(Solve(a), Solve(a.Skip(1).Append(a[0]).ToArray())));
    }
}