// detail: https://codeforces.com/contest/1270/submission/67889365
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            if (2 <= Abs(a[i] - a[i + 1]))
            {
                Console.WriteLine("YES");
                Console.WriteLine($"{i + 1} {i + 2}");
                return;
            }
        }
        Console.WriteLine("NO");
    }
}
