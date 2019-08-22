// detail: https://codeforces.com/contest/1207/submission/59286986
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;

static class P
{
    static void Main()
    {
        var t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var s = Console.ReadLine();
            Console.WriteLine(Solve(nab[0], nab[1], nab[2], s));
        }
    }

    static long Solve(int n, int a, int b, string s)
    {
        long oneCost = b;
        long twoCost = long.MaxValue / 2;

        for (int i = 0; i < s.Length; i++)
        {
            long newOneCost = (s[i] == '0' ? Min(oneCost + a, twoCost + a + a) : long.MaxValue / 2) + b;
            long newTwoCost = (s[i] == '0' ? Min(oneCost + a + a, twoCost + a) : twoCost + a) + b * 2;
            oneCost = newOneCost;
            twoCost = newTwoCost;
        }
        return oneCost;
    }
}