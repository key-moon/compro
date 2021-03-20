// detail: https://atcoder.jp/contests/abc196/submissions/21074365
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
        var hwab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwab[0];
        var w = hwab[1];
        var a = hwab[2];
        var b = hwab[3];
        List<(int, int)> pairs = new List<(int, int)>();

        for (int i = 0; i < h - 1; i++)
            for (int j = 0; j < w; j++)
            { var id = i * w + j; pairs.Add((id, id + w)); }
        for (int i = 0; i < h; i++)
            for (int j = 0; j < w - 1; j++)
            { var id = i * w + j; pairs.Add((id, id + 1)); }

        int res = 0;
        for (int B = 0; B < (1 << pairs.Count); B++)
        {
            bool[] fill = new bool[h * w];
            int cnt = 0;
            for (int i = 0; i < pairs.Count; i++)
            {
                if ((B >> i & 1) != 1) continue;
                cnt++;
                var (g1, g2) = pairs[i];
                if (fill[g1] || fill[g2]) goto invalid;
                fill[g1] = true;
                fill[g2] = true;
            }
            if (cnt != a) goto invalid;
            res++;
            invalid:;
        }
        Console.WriteLine(res);
    }

}