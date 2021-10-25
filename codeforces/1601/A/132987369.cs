// detail: https://codeforces.com/contest/1601/submission/132987369
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
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long gcd = 0;
        for (int i = 0; i < 30; i++)
        {
            var cnt = a.Count(x => (x >> i & 1) == 1);
            gcd = GCD(gcd, cnt);
        }
        List<int> res = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            if (gcd % i == 0) res.Add(i);
        }

        Console.WriteLine(string.Join(" ", res));
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }
}