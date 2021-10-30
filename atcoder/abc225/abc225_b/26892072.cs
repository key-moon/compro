// detail: https://atcoder.jp/contests/abc225/submissions/26892072
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
        List<int>[] @graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            @graph[st[0]].Add(st[1]);
            @graph[st[1]].Add(st[0]);
        }

        Console.WriteLine(graph.Any(x => x.Count == n - 1) ? "Yes" : "No");
    }
}