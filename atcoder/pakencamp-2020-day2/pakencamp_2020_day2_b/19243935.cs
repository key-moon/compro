// detail: https://atcoder.jp/contests/pakencamp-2020-day2/submissions/19243935
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
        var map = Enumerable.Repeat(0, hw[0]).Select(_ => $"{Console.ReadLine()}X").Append(string.Join("", Enumerable.Repeat('X', w + 1))).ToArray();
        h++; w++;
        var cost = map.Select(x => x.Select(_ => int.MaxValue / 2).ToArray()).ToArray();
        cost[0][0] = 0;
        int res = int.MaxValue;
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                var c = map[i][j];
                if (c == 'X') continue;
                cost[i + 1][j] = Min(cost[i + 1][j], cost[i][j] + (c == 'S' ? 0 : 1));
                cost[i][j + 1] = Min(cost[i][j + 1], cost[i][j] + (c == 'E' ? 0 : 1));
            }
        }

        //Console.WriteLine(string.Join("\n", cost.Select(x => string.Join(" ", x))));
        Console.WriteLine(cost[h - 2][w - 1]);
    }
}