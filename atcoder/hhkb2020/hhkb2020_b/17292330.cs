// detail: https://atcoder.jp/contests/hhkb2020/submissions/17292330
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
        var m = Enumerable.Repeat(0, hw[0]).SelectMany(_ => Console.ReadLine()).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, h * w).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; graph[id].Add(id + w); graph[id + w].Add(id); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }
        int res = 0;
        for (int i = 0; i < graph.Length; i++)
        {
            if (m[i] == '#') continue;
            foreach (var item in graph[i])
            {
                if (m[item] != '#') res++;
            }
        }
        Console.WriteLine(res / 2);
    }
}