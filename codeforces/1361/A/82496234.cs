// detail: https://codeforces.com/contest/1361/submission/82496234
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            graph[st[0]].Add(st[1]);
            graph[st[1]].Add(st[0]);
        }

        var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var maxTopics = new int[n];

        var rng = new Random();

        List<int> res = new List<int>();
        foreach (var item in t.Select((item, ind) => new { item, ind }).GroupBy(x => x.item).OrderBy(_ => rng.Next()).OrderBy(x => x.Key))
        {
            var topic = item.Key;
            foreach (var node in item)
            {
                if (maxTopics[node.ind] != topic - 1)
                {
                    Console.WriteLine(-1);
                    return;
                }
                foreach (var neighbor in graph[node.ind])
                {
                    if (maxTopics[neighbor] == topic - 1)
                    {
                        maxTopics[neighbor] = topic;
                    }
                }
                res.Add(node.ind + 1);
            }
        }

        Console.WriteLine(string.Join(" ", res));
    }
}
