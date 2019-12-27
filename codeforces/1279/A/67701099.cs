// detail: https://codeforces.com/contest/1279/submission/67701099
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
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var rgb = Console.ReadLine().Split().Select(long.Parse).ToArray();

        Console.WriteLine(rgb.Max() <= (rgb.Sum() + 1) / 2 ? "Yes" : "No");
    }
}
