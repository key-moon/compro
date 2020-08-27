// detail: https://atcoder.jp/contests/abc148/submissions/16271406
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
        if (n % 2 == 1)
        {
            Console.WriteLine(0);
            return;
        }
        long res = 0;
        for (long i = 10; i <= n; i *= 5)
        {
            res += n / i;
        }
        Console.WriteLine(res);
    }
}