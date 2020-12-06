// detail: https://codeforces.com/contest/1450/submission/100535933
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
        var grid = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().ToArray()).ToArray();
        int[] cnt = new int[3];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 'X') cnt[(i + j) % 3]++;
            }
        }
        var minInd = Array.IndexOf(cnt, cnt.Min());
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if ((i + j) % 3 == minInd && grid[i][j] != '.') grid[i][j] = 'O';
            }
        }

        Console.WriteLine(string.Join("\n", grid.Select(x => string.Join("", x))));
    }
}