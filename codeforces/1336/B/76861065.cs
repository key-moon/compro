// detail: https://codeforces.com/contest/1336/submission/76861065
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++) Solve();
    }
    static Random rng = new Random();
    public static void Solve()
    {
        var counts = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = Console.ReadLine().Split().Select(long.Parse).OrderBy(_ => rng.Next()).OrderBy(x => x).ToArray();
        var g = Console.ReadLine().Split().Select(long.Parse).OrderBy(_ => rng.Next()).OrderBy(x => x).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).OrderBy(_ => rng.Next()).OrderBy(x => x).ToArray();
        var res1 = Solve(r, g, b);
        var res2 = Solve(g, b, r);
        var res3 = Solve(b, r, g);
        Console.WriteLine(Min(res1, Min(res2, res3)));
    }
    public static long Solve(long[] a, long[] b, long[] c)
    {
        long res = long.MaxValue;
        foreach (var aItem in a)
        {
            var bItem = FindItem(b, aItem);
            var cItem = FindItem(c, aItem);
            var curRes = Calc(aItem, bItem, cItem);
            if (curRes < 0) throw new Exception();
            res = Min(res, curRes);
        }
        return res;
    }
    static long FindItem(long[] b, long aItem)
    {
        var ind = FindInd(b, aItem);
        long bItem, bAbove, bBelow;
        bAbove = ind == b.Length ? int.MaxValue : b[ind];
        bBelow = ind == 0 ? int.MinValue : b[ind - 1];
        bItem = bAbove - aItem > aItem - bBelow ? bBelow : bAbove;
        return bItem;
    }
    static int FindInd(long[] a, long n)
    {
        var valid = a.Length;
        var invalid = -1;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (n <= a[mid]) valid = mid;
            else invalid = mid;
        }
        return valid;
    }
    static long Calc(long a, long b, long c)
    {
        return (b - a) * (b - a) + (c - b) * (c - b) + (c - a) * (c - a);
    }
}