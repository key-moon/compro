// detail: https://codeforces.com/contest/797/submission/105561652
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
        var sum = a.Where(x => 0 <= x && (x & 1) == 0).Append(0).Sum();
        long res = long.MinValue;
        foreach (var item in a.Where(x => (x & 1) == 1).OrderByDescending(x => x))
        {
            sum += item;
            if ((sum & 1) == 1) res = Max(res, sum);
        }
        Console.WriteLine(res);
    }
}