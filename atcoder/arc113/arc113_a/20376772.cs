// detail: https://atcoder.jp/contests/arc113/submissions/20376772
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
        int k = int.Parse(Console.ReadLine());
        long res = 0;
        for (int i = 1; i <= k; i++)
        {
            long ab = 0;
            for (long a = 1; a * a <= i; a++)
            {
                if (i % a != 0) continue;
                ab++;
                if (a * a != i) ab++;
            }
            long c = k / i;
            res += ab * c;
        }
        Console.WriteLine(res);
    }
}