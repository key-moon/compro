// detail: https://atcoder.jp/contests/abc182/submissions/17962350
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
        var hwnm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwnm[0];
        var w = hwnm[1];
        var n = hwnm[2];
        var m = hwnm[3];
        int[][] grid = Enumerable.Repeat(0, h).Select(_ => new int[w]).ToArray();
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = ab[0] - 1;
            var b = ab[1] - 1;
            grid[a][b] = 2;
        }
        for (int i = 0; i < m; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = ab[0] - 1;
            var b = ab[1] - 1;
            grid[a][b] = -1;
        }
        for (int i = 0; i < h; i++)
        {
            bool light = false;
            for (int j = 0; j < w; j++)
            {
                if (grid[i][j] == 2) light = true;
                else if (grid[i][j] == -1) light = false;
                else if (light) grid[i][j] = 1;
            }
            light = false;
            for (int j = w - 1; j >= 0; j--)
            {
                if (grid[i][j] == 2) light = true;
                else if (grid[i][j] == -1) light = false;
                else if (light) grid[i][j] = 1;
            }
        }
        for (int j = 0; j < w; j++)
        {
            bool light = false;
            for (int i = 0; i < h; i++)
            {
                if (grid[i][j] == 2) light = true;
                else if (grid[i][j] == -1) light = false;
                else if (light) grid[i][j] = 1;
            }
            light = false;
            for (int i = h - 1; i >= 0; i--)
            {
                if (grid[i][j] == 2) light = true;
                else if (grid[i][j] == -1) light = false;
                else if (light) grid[i][j] = 1;
            }
        }
        int res = 0;
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (1 <= grid[i][j]) res++;
            }
        }
        Console.WriteLine(res);
    }
}