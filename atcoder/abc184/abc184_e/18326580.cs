// detail: https://atcoder.jp/contests/abc184/submissions/18326580
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];

        var map = Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine().ToArray()).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; graph[id].Add(id + w); graph[id + w].Add(id); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }

        var start = Array.IndexOf(map, 'S');
        var goal = Array.IndexOf(map, 'G');
        int[][] places = new int[26][];
        foreach (var item in map.Select((x, y) => (x, y)).GroupBy(x => x.x))
        {
            var key = item.Key;
            if ('a' <= key && key <= 'z')
            {
                places[key - 'a'] = item.Select(x => x.y).ToArray();
            }
        }

        const int INF = int.MaxValue / 2;
        int[] res = Enumerable.Repeat(INF, h * w).ToArray();
        Queue<int> stack = new Queue<int>();
        stack.Enqueue(start);
        res[start] = 0;
        while (stack.Count != 0)
        {
            var elem = stack.Dequeue();
            var nxtCost = res[elem] + 1;
            if ('a' <= map[elem] && map[elem] <= 'z')
            {
                if (!(places[map[elem] - 'a'] is null))
                {
                    foreach (var adj in places[map[elem] - 'a'])
                    {
                        if (res[adj] != INF) continue;
                        res[adj] = nxtCost;
                        stack.Enqueue(adj);
                    }
                    places[map[elem] - 'a'] = null;
                }
            }
            foreach (var adj in graph[elem])
            {
                if (res[adj] != INF) continue;
                if (map[adj] == '#') continue;
                res[adj] = nxtCost;
                stack.Enqueue(adj);
            }
        }

        Console.WriteLine(res[goal] == INF ? -1 : res[goal]);
    }
}