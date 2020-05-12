// detail: https://codeforces.com/contest/1349/submission/79862343
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
        var nmt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmt[0];
        var m = nmt[1];
        var t = nmt[2];
        var map = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Select(x => x - '0').ToArray()).ToArray();
        int[][] dist = Enumerable.Range(0, n).Select(_ => Enumerable.Repeat(int.MaxValue, m).ToArray()).ToArray();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m - 1; j++)
                if (map[i][j] == map[i][j + 1]) dist[i][j] = dist[i][j + 1] = 0;
 
        for (int j = 0; j < m; j++)
            for (int i = 0; i < n - 1; i++)
                if (map[i][j] == map[i + 1][j]) dist[i][j] = dist[i + 1][j] = 0;

        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        for (int i = 0; i < dist.Length; i++)
            for (int j = 0; j < dist[i].Length; j++)
                if (dist[i][j] == 0) queue.Enqueue(new Tuple<int, int>(i, j));

        var ydir = new int[] { 0, -1, 0, 1 };
        var xdir = new int[] { 1, 0, -1, 0 };


        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });

        while (queue.Count > 0)
        {
            var elem = queue.Dequeue();
            var nextDist = dist[elem.Item1][elem.Item2] + 1;
            for (int i = 0; i < 4; i++)
            {
                var nexty = elem.Item1 + ydir[i];
                var nextx = elem.Item2 + xdir[i];
                if (nexty < 0 || n <= nexty || nextx < 0 || m <= nextx || dist[nexty][nextx] != int.MaxValue) continue;
                dist[nexty][nextx] = nextDist;
                queue.Enqueue(new Tuple<int, int>(nexty, nextx));
            }
        }

        for (int i = 0; i < t; i++)
        {
            var ijp = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var y = ijp[0] - 1;
            var x = ijp[1] - 1;
            var p = ijp[2];
            int res;
            if (dist[y][x] == int.MaxValue || p < dist[y][x]) res = map[y][x];
            else res = map[y][x] ^ ((int)(p - dist[y][x]) & 1);
            Console.WriteLine(res);
        }

        Console.Out.Flush();
    }
}