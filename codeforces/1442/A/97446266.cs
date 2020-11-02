// detail: https://codeforces.com/contest/1442/submission/97446266
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
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < k; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var last = a[0];
        var curminus = 0;
        foreach (var item in a)
        {
            curminus += Max(last - item, 0);
            last = item;
        }
        for (int i = 0; i < n; i++)
        {
            if (a[i] - curminus < 0)
            {
                Console.WriteLine("NO");
                return;
            }
            if (i == n - 1) continue;
            curminus -= Max(a[i] - a[i + 1], 0);
        }

        Console.WriteLine("YES");
    }
}
