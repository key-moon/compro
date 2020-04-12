// detail: https://atcoder.jp/contests/abc162/submissions/11800314
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
        var n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var rCount = (long)s.Count(x => x == 'R');
        var gCount = (long)s.Count(x => x == 'G');
        var bCount = (long)s.Count(x => x == 'B');
        var res = rCount * gCount * bCount;
        for (int i = 1; i < s.Length - 1; i++)
        {
            for (int j = i - 1, k = i + 1; 0 <= j && k < s.Length; j--, k++)
            {
                if (s[i] != s[j] && s[i] != s[k] && s[j] != s[k]) res--;
            }
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