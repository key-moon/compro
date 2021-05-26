// detail: https://atcoder.jp/contests/abc019/submissions/22930495
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
        int max = 0;
        int maxInd = 0;
        for (int i = 2; i <= n; i++)
        {
            Console.WriteLine($"? 1 {i}");
            var d = int.Parse(Console.ReadLine());
            if (max < d) (max, maxInd) = (d, i);
        }
        int res = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i == maxInd) continue;
            Console.WriteLine($"? {maxInd} {i}");
            var d = int.Parse(Console.ReadLine());
            if (res < d) res = d;
        }
        Console.WriteLine($"! {res}");
    }
}