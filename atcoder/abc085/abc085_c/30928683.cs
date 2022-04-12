// detail: https://atcoder.jp/contests/abc085/submissions/30928683
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
        var ny = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = ny[0];
        var y = ny[1];

        int res = 0;
        for (long i = 0; i <= n; i++)
        {
            for (long j = 0; j + i <= n; j++)
            {
                long k = n - i - j;
                if (i * 10000 + j * 5000 + k * 1000 == y)
                {
                    Console.WriteLine($"{i} {j} {k}");
                    return;
                }
            }
        }
        Console.WriteLine("-1 -1 -1");
    }
}