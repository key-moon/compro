// detail: https://yukicoder.me/submissions/547845
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();

        int[] degree = new int[n];
        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n - 1; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
            degree[st[0]]++;
            degree[st[1]]++;
        }

        Func<int, int, Tuple<long, long>> solve = null;
        solve = (int node, int parent) =>
        {
            var remainSum = 0L;
            var deleteSum = a[node];
            foreach (var adj in graph[node])
            {
                if (adj == parent) continue;
                var res = solve(adj, node);
                var remain = res.Item1;
                var delete = res.Item2;
                deleteSum += Max(remain, delete);
                remain += b[adj] + b[node];
                remainSum += Max(remain, delete);
            }
            return new Tuple<long, long>(remainSum, deleteSum);
        };
        var totalRes = solve(0, -1);
        Console.WriteLine(Max(totalRes.Item1, totalRes.Item2));
    }
}