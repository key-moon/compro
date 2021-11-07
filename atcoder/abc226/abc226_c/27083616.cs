// detail: https://atcoder.jp/contests/abc226/submissions/27083616
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

        var arrs = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (x[0], x[2..])).ToArray();

        bool[] need = new bool[n];
        need[n - 1] = true;
        long res = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (!need[i]) continue;
            var (t, deps) = arrs[i];
            res += t;
            foreach (var dep in deps) need[dep - 1] = true; 
        }
        Console.WriteLine(res);
    }
}
