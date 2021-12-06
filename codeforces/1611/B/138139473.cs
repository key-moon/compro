// detail: https://codeforces.com/contest/1611/submission/138139473
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        if (a < b) (a, b) = (b, a);
        int res = 0;
        
        var d = Min((a - b) / 2, b);
        res += d;
        a -= d * 3;
        b -= d;

        d = Min(a, b) / 2;
        res += d;
        a -= d * 2;
        b -= d * 2;

        Console.WriteLine(res);
    }
}