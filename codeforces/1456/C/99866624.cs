// detail: https://codeforces.com/contest/1456/submission/99866624
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        long cur = 0;
        int column = k + 1;
        for (int i = n - 1; i >= 0; i--)
        {
            var height = i / column;
            cur += height * a[i];
        }
        long res = cur;

        long pillar = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (i % column != column - 1) cur += pillar;
            pillar += a[i];
            res = Max(res, cur);
        }
        Console.WriteLine(res);
    }
}
