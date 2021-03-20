// detail: https://atcoder.jp/contests/joi2011yo/submissions/21050361
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
        var hwn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwn[0];
        var w = hwn[1];
        var n = hwn[2];
        var grid = Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine()).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; graph[id].Add(id + w); graph[id + w].Add(id); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }

        int GetDist(int id1, int id2)
        {
            var queue = new Queue<int>();
            int[] dist = Enumerable.Repeat(int.MaxValue / 2, h * w).ToArray();
            queue.Enqueue(id1);
            dist[id1] = 0;

            while (queue.Count != 0)
            {
                var elem = queue.Dequeue();
                var nxtdist = dist[elem] + 1;
                foreach (var adj in graph[elem])
                {
                    if (grid[adj] == 'X') continue;
                    if (dist[adj] <= nxtdist) continue;
                    dist[adj] = nxtdist;
                    queue.Enqueue(adj);
                }
            }

            return dist[id2];
        }

        int res = 0;
        var prevind = Array.IndexOf(grid, 'S');
        for (int i = 1; i <= n; i++)
        {
            var curind = Array.IndexOf(grid, (char)('0' + i));
            res += GetDist(prevind, curind);
            prevind = curind;
        }
        Console.WriteLine(res);
    }
}