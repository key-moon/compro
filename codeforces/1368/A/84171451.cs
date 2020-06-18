// detail: https://codeforces.com/contest/1368/submission/84171451
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
        var abn = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = abn[0];
        var b = abn[1];
        var n = abn[2];
        Console.WriteLine(Min(Solve(a, b, n), Solve(b, a, n)));
    }
    static int Solve(long a, long b, long n)
    {
        int res = 0;
        while (true)
        {
            if (a > n || b > n) return res;
            a += b;
            res++;
            if (a > n || b > n) return res;
            b += a;
            res++;
        }
    }
}
