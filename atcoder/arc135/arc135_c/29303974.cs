// detail: https://atcoder.jp/contests/arc135/submissions/29303974
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long res = a.Sum();
        int[] bitCount = new int[31];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                bitCount[j] += (int)(a[i] >> j & 1);
            }
        }
        foreach (var item in a)
        {
            long sum = 0;
            for (int j = 0; j < 30; j++)
            {
                var cnt = bitCount[j];
                if ((item >> j & 1) == 1)
                {
                    cnt = n - cnt;
                }
                sum += cnt * (1L << j);
            }
            res = Max(res, sum);
        }
        Console.WriteLine(res);
    }
}