// detail: https://codeforces.com/contest/1426/submission/95959936
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
        long n = long.Parse(Console.ReadLine());
        var sqrt = (int)Ceiling(Sqrt(n));
        var time = (n + sqrt - 1) / sqrt;
        Console.WriteLine(sqrt + time - 2);
    }
}
