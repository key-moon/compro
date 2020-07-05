// detail: https://atcoder.jp/contests/abc173/submissions/14975385
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
        var hwk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwk[0];
        var w = hwk[1];
        var k = hwk[2];
        var c = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine()).ToArray();
        int res = 0;
        for (int i = 0; i < (1 << h); i++)
        {
            for (int j = 0; j < (1 << w); j++)
            {
                var newc = c.Select(x => x.ToArray()).ToArray();
                for (int y = 0; y < h; y++)
                {
                    if ((i >> y & 1) == 1)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            newc[y][x] = '.';
                        }
                    }
                }
                for (int x = 0; x < w; x++)
                {
                    if ((j >> x & 1) == 1)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            newc[y][x] = '.';
                        }
                    }
                }
                if (newc.Sum(x => x.Count(y => y == '#')) == k)
                {
                    res++;
                }
            }
        }
        Console.WriteLine(res);
    }
}