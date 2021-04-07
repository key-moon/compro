// detail: https://atcoder.jp/contests/abc144/submissions/21551789
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
        long min = long.MaxValue;
        for (long i = 1; i * i <= n; i++)
        {
            if (n % i != 0) continue;
            var j = n / i;
            min = Min(min, i + j - 2);
        }
        Console.WriteLine(min);
    }
}