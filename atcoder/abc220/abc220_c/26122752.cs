// detail: https://atcoder.jp/contests/abc220/submissions/26122752
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
        long x = long.Parse(Console.ReadLine());
        var asum = a.Sum();
        var cnt =  x / asum * n;
        x -= x / asum * asum;
        foreach (var item in a)
        {
            x -= item;
            cnt++;
            if (x < 0) break;
        }
        Console.WriteLine(cnt);
    }
}