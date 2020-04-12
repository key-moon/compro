// detail: https://atcoder.jp/contests/abc162/submissions/11793240
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
        long res = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 != 0 && i % 5 != 0) res += i;
        }
        Console.WriteLine(res);
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
}