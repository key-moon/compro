// detail: https://codeforces.com/contest/1479/submission/106837007
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
        var lr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var l = lr[0];
        var r = lr[1];

        var n = 22;
        List<(int, int)>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<(int, int)>()).ToArray();
        for (int i = n - 2; i >= 1; i--)
        {
            graph[i].Add((n - 1, 1));
            for (int j = i + 1; j < n - 1; j++) graph[i].Add((j, 1 << (n - 2 - j)));
        }
        graph[0].Add((n - 1, l));
        l++;
        for (int i = 1; i < n - 1; i++)
        {
            var cnt = 1 << (n - 2 - i);
            var need = r - l + 1;
            if (need < cnt) continue;
            graph[0].Add((i, l - 1));
            l += cnt;
        }
        var cache = new int[n][];
        cache[n - 1] = new[] { 0 };
        int[] DFS(int node)
        {
            if (cache[node] != null) return cache[node];
            var res = Enumerable.Empty<int>();
            foreach (var item in graph[node])
            {
                res = res.Concat(DFS(item.Item1).Select(x => x + item.Item2));
            }
            return cache[node] = res.ToArray();
        }

        Console.WriteLine("YES");
        var edges = graph.SelectMany((elem, ind) => elem.Select(x => $"{ind + 1} {x.Item1 + 1} {x.Item2}")).ToArray();
        Console.WriteLine($"{n} {edges.Length}");
        Console.WriteLine(string.Join("\n", edges));

        //Console.WriteLine(DFS(0).Count() == DFS(0).Distinct().Count());
        //Console.WriteLine($"{DFS(0).Min()} {DFS(0).Max()}");
    }
}