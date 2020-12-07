// detail: https://codeforces.com/contest/678/submission/100618373
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
        var nabpq = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nabpq[0];
        var a = nabpq[1];
        var b = nabpq[2];
        var p = nabpq[3];
        var q = nabpq[4];
        var lcm = LCM(a, b);
        Console.WriteLine((n / a - n / lcm) * p + (n / b - n / lcm) * q + (n / lcm) * Max(p, q));
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }

    static long LCM(long a, long b) { return a / GCD(a, b) * b; }
}