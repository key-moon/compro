// detail: https://atcoder.jp/contests/keyence2021/submissions/19474678
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
    static bool[][][] Cache = new bool[9][][]
    {
        new[] { new bool[] { true } },
        new[] { new bool[] { true, true }, new bool[] { true, false } },
        null, null, null, null, null, null, null
    };
    static bool[][] Solve(int n)
    {
        if (Cache[n] != null) return Cache[n];
        int size = 1 << n;
        bool[][] res = Enumerable.Repeat(0, size).Select(_ => new bool[size]).ToArray();
        var prev = Solve(n - 1);
        for (int i = 0; i < prev.Length; i++)
            for (int j = 0; j < prev[i].Length; j++)
            {
                res[i * 2][j] = prev[i][j];
                res[i * 2 + 1][j] = prev[i][j];
                res[i][j * 2] = prev[i][j];
                res[i][j * 2 + 1] = prev[i][j];
            }
        var corner = Solve(n - 2);
        for (int i = 0; i < corner.Length; i++)
        {
            for (int j = 0; j < corner[i].Length; j++)
            {
                var offsetY = size / 2 + i * 2;
                var offsetX = size / 2 + j * 2;
                res[offsetY][offsetX] = res[offsetY + 1][offsetX + 1] = corner[i][j];
                res[offsetY + 1][offsetX] = res[offsetY][offsetX + 1] = !corner[i][j];
            }
        }
        return Cache[n] = res;
    }
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var res = Solve(n);
        Console.WriteLine(res.Length - 1);
        for (int i = 1; i < res.Length; i++) Console.WriteLine(string.Join("", res[i].Select(x => x ? 'A' : 'B')));
    }
}