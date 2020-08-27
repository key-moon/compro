// detail: https://atcoder.jp/contests/abc148/submissions/16271397
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
        int cur = 1;
        int res = 0;
        foreach (var item in a)
        {
            if (item == cur)
            {
                cur++;
            }
            else res++;
        }
        if (res == n) res = -1;
        Console.WriteLine(res);
    }
}