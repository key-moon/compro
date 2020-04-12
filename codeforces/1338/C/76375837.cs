// detail: https://codeforces.com/contest/1338/submission/76375837
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
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++) Solve();
        Console.Out.Flush();
    }
    static int[][] Digs = new[]
    {
        new[]{ 0, 1, 2, 3 },
        new[]{ 0, 2, 3, 1 },
        new[]{ 0, 3, 1, 2 }
    };
    static void Solve()
    {
        var n = long.Parse(Console.ReadLine());
        long pow = 4;
        while (pow <= n) pow <<= 2;
        var blockBegin = pow >> 2;
        var offset = n - blockBegin;
        var kind = offset % 3;
        var cycle = offset / 3;
        long res = (kind + 1) * (pow >> 2);
        pow = 1;
        while ((pow * 3 & res) == 0)
        {
            res |= pow * Digs[kind][cycle & 3];
            cycle >>= 2;
            pow <<= 2;
        }
        Console.WriteLine(res);
    }
}