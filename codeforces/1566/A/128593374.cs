// detail: https://codeforces.com/contest/1566/submission/128593374
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
        var ns = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = ns[0];
        var s = ns[1];
        var cnt = n / 2 + 1;
        Console.WriteLine(s / cnt);
    }
}