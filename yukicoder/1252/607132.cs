// detail: https://yukicoder.me/submissions/607132
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
        for (int i = 0; i < t; i++) Solve();
    }
    static void Solve()
    {
        var dab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var d = dab[0];
        long a = dab[1];
        long b = dab[2];
        Console.WriteLine(Solve(d, b) - Solve(d, a - 1));
    }
    static long Solve(long d, long a)
    {
        if (a <= 0) return 0;
        long loop = a / (d - 1);
        long remain = a % (d - 1);
        return (d * (d - 1) / 2) * loop + (remain * (remain + 1)) / 2;
    }
}