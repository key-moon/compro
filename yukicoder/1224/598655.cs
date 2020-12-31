// detail: https://yukicoder.me/submissions/598655
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
        var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var den = ab[1] / GCD(ab[0], ab[1]);
        while (den % 2 == 0) den /= 2;
        while (den % 5 == 0) den /= 5;
        Console.WriteLine(den != 1 ? "Yes" : "No");
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