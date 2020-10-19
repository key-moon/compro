// detail: https://codeforces.com/contest/1426/submission/95958965
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
        for (int i = 0; i < t; i++)
        {
            Solve();

        }

    }
    static void Solve()
    {
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nx[0];
        var x = nx[1];
        if (n <= 2)
        {
            Console.WriteLine(1);
            return;
        }
        Console.WriteLine((n + (x - 3)) / x + 1);
    }
}
