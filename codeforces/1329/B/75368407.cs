// detail: https://codeforces.com/contest/1329/submission/75368407
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
        var dm = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var d = dm[0];
        var m = dm[1];
        long res = 1;
        long curPow = 1;
        while (true)
        {
            var lastPow = curPow;
            curPow <<= 1;
            if (d < curPow)
            {
                res *= (d - lastPow + 1 + 1);
                res %= m;
                break;
            }
            res *= (curPow - lastPow + 1);
            res %= m;
        }
        Console.WriteLine((res + m - 1) % m);
    }
}
