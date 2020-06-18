// detail: https://codeforces.com/contest/1368/submission/84191361
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
        string cf = "codeforces";
        var k = long.Parse(Console.ReadLine());
        long[] counts = Enumerable.Repeat(1L, cf.Length).ToArray();
        int ind = 0;
        while (true)
        {
            if (k <= counts.Aggregate(1L, (x, y) => x * y)) break;
            counts[ind]++;
            ind = (ind + 1) % counts.Length;
        }
        Console.WriteLine(string.Join("", counts.SelectMany((count, i) => Enumerable.Repeat(cf[i], (int)count))));
    }
}