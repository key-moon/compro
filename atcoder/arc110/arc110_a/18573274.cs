// detail: https://atcoder.jp/contests/arc110/submissions/18573274
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
        var res = Enumerable.Range(1, n).Select(x => (long)x).Aggregate(1L, LCM);
        if (res >= 1e13) throw new Exception();
        Console.WriteLine(res + 1);
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