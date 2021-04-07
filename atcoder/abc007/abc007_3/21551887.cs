// detail: https://atcoder.jp/contests/abc007/submissions/21551887
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
        var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var (r, c) = (rc[0], rc[1]);
        var s = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var (sy, sx) = (s[0] - 1, s[1] - 1);
        var g = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var (gy, gx) = (g[0] - 1, g[1] - 1);

        var grid = Enumerable.Repeat(0, r).SelectMany(_ => Console.ReadLine()).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, r * c).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < r - 1; i++)
            for (int j = 0; j < c; j++)
            { var id = i * c + j; graph[id].Add(id + c); graph[id + c].Add(id); }
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c - 1; j++)
            { var id = i * c + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }

        int[] dist = Enumerable.Repeat(int.MaxValue / 2, r * c).ToArray();

        Queue<int> q = new Queue<int>();
        q.Enqueue(sy * c + sx);
        dist[sy * c + sx] = 0;
        while (q.Count != 0)
        {
            var elem = q.Dequeue();
            var nextDist = dist[elem] + 1;
            foreach (var item in graph[elem])
            {
                if (dist[item] <= nextDist) continue;
                if (grid[item] == '#') continue;
                q.Enqueue(item);
                dist[item] = nextDist;
            }
        }
        Console.WriteLine(dist[gy * c + gx]);
    }
}