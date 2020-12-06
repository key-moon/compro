// detail: https://codeforces.com/contest/1450/submission/100525423
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
        for (int i = 0; i < n; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        Console.WriteLine(string.Join("", s.OrderBy(x => x)));
    }
}