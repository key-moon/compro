// detail: https://codeforces.com/contest/1384/submission/96376279
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
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[] prev = Enumerable.Repeat('a', 120).ToArray();

        Console.WriteLine(string.Join("", prev));
        foreach (var item in a)
        {
            for (int i = item; i < prev.Length; i++)
            {
                prev[i] = prev[i] == 'z' ? 'a' : (char)(prev[i] + 1);
            }
            Console.WriteLine(string.Join("", prev));
        }

    }
}
