// detail: https://codeforces.com/contest/1392/submission/90095033
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        if (k % 2 == 1)
        {
            var d = a.Max();
            Console.WriteLine(string.Join(" ", a.Select(x => d - x)));
        }
        else
        {
            var d = a.Min();
            Console.WriteLine(string.Join(" ", a.Select(x => x - d)));
        }
    }
}
