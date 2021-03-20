// detail: https://atcoder.jp/contests/abc196/submissions/21066436
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
        var n = long.Parse(Console.ReadLine());
        long res = 0;
        for (long i = 1; ; i++)
        {
            if (n < long.Parse($"{i}{i}")) break;
            res++;
        }
        Console.WriteLine(res);
    }
}