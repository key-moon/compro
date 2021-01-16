// detail: https://atcoder.jp/contests/keyence2021/submissions/19461711
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
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long maxA = 0;
        long maxElem = 0;
        long[] res = new long[n];
        for (int i = 0; i < n; i++)
        {
            maxA = Max(maxA, a[i]);
            maxElem = Max(maxElem, maxA * b[i]);
            res[i] = maxElem;
        }

        Console.WriteLine(string.Join("\n", res));
    }
}