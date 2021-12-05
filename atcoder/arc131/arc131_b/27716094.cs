// detail: https://atcoder.jp/contests/arc131/submissions/27716094
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
        var g = Enumerable.Repeat(0, h).SelectMany(_ => Console.ReadLine()).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; graph[id].Add(id + w); graph[id + w].Add(id); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }

        for (int i = 0; i < h * w; i++)
        {
            if (char.IsDigit(g[i])) continue;
            bool[] has = new bool[5];
            foreach (var adj in graph[i])
            {
                if (char.IsDigit(g[adj])) has[g[adj] - '1'] = true;
            }
            g[i] = (char)(Array.IndexOf(has, false) + '1');
        }
        for (int i = 0; i < h; i++)
        {
            Console.WriteLine(g[(i * w)..((i + 1) * w)]);
        }
    }
}