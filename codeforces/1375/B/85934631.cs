// detail: https://codeforces.com/contest/1375/submission/85934631
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var grid = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                var count = 4;
                if (i == 0 || i == n - 1) count--;
                if (j == 0 || j == m - 1) count--;
                if (grid[i][j] > count)
                {
                    Console.WriteLine("NO");
                    return;
                }
                grid[i][j] = count;
            }
        }
        Console.WriteLine("YES");


        Console.WriteLine(string.Join("\n", grid.Select(x => string.Join(" ", x))));
    }
}