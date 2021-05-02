// detail: https://codeforces.com/contest/1515/submission/114872516
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
        var n = long.Parse(Console.ReadLine());
        Console.WriteLine((n % 2 == 0 && IsSqrt(n / 2)) || (n % 4 == 0 && IsSqrt(n / 4)) ? "YES" : "NO");
    }
    static bool IsSqrt(long n)
    {
        var sqrt = (long)Round(Sqrt(n));
        return sqrt * sqrt == n;
    }
}