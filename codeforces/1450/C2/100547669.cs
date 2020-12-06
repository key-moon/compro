// detail: https://codeforces.com/contest/1450/submission/100547669
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
        var patterns = new string[]
        {
            "OX.",
            "O.X",
            "XO.",
            "X.O",
            ".OX",
            ".XO"
        };
        var min = int.MaxValue;
        char[][] minGrid = null;
        foreach (var pattern in patterns)
        {
            int cur = 0;
            var copied = grid.Select(x => x.ToArray()).ToArray();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var should = pattern[(i + j) % 3];
                    if (should == '.' || copied[i][j] == '.') continue;
                    if (copied[i][j] != should)
                    {
                        cur++;
                        copied[i][j] = should;
                    }
                }
            }
            if (min <= cur) continue;
            min = cur;
            minGrid = copied;
        }
        if (n * n < min * 3) throw new Exception();
        Console.WriteLine(string.Join("\n", minGrid.Select(x => string.Join("", x))));
    }
}