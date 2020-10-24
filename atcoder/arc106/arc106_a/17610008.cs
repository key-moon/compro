// detail: https://atcoder.jp/contests/arc106/submissions/17610008
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
        for (BigInteger pow3 = 3, a = 1; pow3 <= n; pow3 *= 3, a++)
        {
            for (BigInteger pow5 = 5, b = 1; pow5 <= n; pow5 *= 5, b++)
            {
                if (pow3 + pow5 == n)
                {
                    Console.WriteLine($"{a} {b}");
                    return;
                }
            }
        }
        Console.WriteLine(-1);
    }
}
