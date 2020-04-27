// detail: https://atcoder.jp/contests/agc032/submissions/12440335
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
        bool isOdd = false;
        if (n % 2 == 1)
        {
            isOdd = true;
            n -= 1;
        }
        List<Tuple<int, int>> edges = new List<Tuple<int, int>>();
        for (int i = 1; i <= n; i++)
        {
            for (int j = i + 1; j <= n; j++)
            {
                if (i + j == n + 1) continue;
                edges.Add(new Tuple<int, int>(i, j));
            }
        }
        if (isOdd)
        {
            for (int i = 1; i <= n; i++)
            {
                edges.Add(new Tuple<int, int>(i, n + 1));
            }
        }
        Console.WriteLine(edges.Count);
        Console.WriteLine(string.Join("\n", edges.Select(x => $"{x.Item1} {x.Item2}")));
    }
}