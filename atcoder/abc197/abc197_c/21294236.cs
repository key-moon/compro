// detail: https://atcoder.jp/contests/abc197/submissions/21294236
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int min = int.MaxValue;
        for (int i = 0; i < (1 << n); i++)
        {
            int prev = 0;
            int cur = 0;
            int res = 0;
            for (int j = 0; j < n; j++)
            {
                var bit = (i >> j & 1);
                if (prev != bit)
                {
                    res ^= cur;
                    cur = 0;
                }
                cur |= a[j];
            }
            res ^= cur;
            min = Min(min, res);
        }
        Console.WriteLine(min);
    }
}
