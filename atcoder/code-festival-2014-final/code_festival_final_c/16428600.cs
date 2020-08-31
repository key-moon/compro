// detail: https://atcoder.jp/contests/code-festival-2014-final/submissions/16428600
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
        long n = long.Parse(Console.ReadLine());
        int res = -1;
        for (int i = 10; i <= 10000; i++)
        {
            long fn = 0;
            long b = 1;
            foreach (var c in i.ToString().Reverse().Select(x => x - '0'))
            {
                fn += b * c;
                b *= i;
            }
            if (fn == n) res = i;
            if (fn >= n) break;
        }
        Console.WriteLine(res);
    }
}