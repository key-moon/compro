// detail: https://codeforces.com/contest/1427/submission/95093192
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var sum = a.Sum();
        if (sum == 0)
        {
            Console.WriteLine("NO");
            return;
        }
        Console.WriteLine("YES");
        if (sum < 0)
        {
            Console.WriteLine(string.Join(" ", a.OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine(string.Join(" ", a.OrderByDescending(x => x)));
        }
    }
}