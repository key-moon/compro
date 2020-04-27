// detail: https://atcoder.jp/contests/agc015/submissions/12440413
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
        var nab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nab[0];
        var a = nab[1];
        var b = nab[2];
        if (n == 1)
        {
            if (a != b)
            {
                Console.WriteLine(0);
                return;
            }
            Console.WriteLine(1);
            return;
        }
        if (a <= b) Console.WriteLine((b - a) * (n - 2) + 1);
        else Console.WriteLine(0);
    }
}