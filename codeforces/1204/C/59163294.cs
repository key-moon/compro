// detail: https://codeforces.com/contest/1204/submission/59163294
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //非単純有向グラフが与えられる
        bool[][] adjacencyMatrix = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Select(x => x == '1').ToArray()).ToArray();
        int[][] shortestPath = Enumerable.Range(0, n).Select(x => adjacencyMatrix[x].Select(y => y ? 1 : int.MaxValue / 2).ToArray()).ToArray();

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    shortestPath[j][k] = Min(shortestPath[j][k], shortestPath[j][i] + shortestPath[i][k]);

        var m = int.Parse(Console.ReadLine());
        var p = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        List<int> res = new List<int>();
        var lastPlaceInd = 0;
        for (int i = 1; i < m; i++)
        {
            if (p[i] != p[lastPlaceInd] && shortestPath[p[lastPlaceInd]][p[i]] == i - lastPlaceInd) continue;
            res.Add(p[lastPlaceInd]);
            lastPlaceInd = i - 1;
        }
        res.Add(p[lastPlaceInd]);
        if (lastPlaceInd != m - 1) res.Add(p.Last());
        //前で止めておいた場合もっと長い最短路が取れたのに、あとまで行ったから… みたいなことはあるか
        Console.WriteLine(res.Count);
        Console.WriteLine(string.Join(" ", res.Select(x => x + 1)));
    }
}