// detail: https://codeforces.com/contest/1611/submission/138139593
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var max = a.Max();
        int[] res = null;
        if (a[0] == max)
        {
            res = a.Skip(1).Reverse().Prepend(max).ToArray();
        }
        if (a[^1] == max)
        {
            res = a.SkipLast(1).Reverse().Append(max).ToArray();
        }
        if (res is null)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(string.Join(" ", res));
        }
    }
}