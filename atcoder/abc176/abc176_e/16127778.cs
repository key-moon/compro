// detail: https://atcoder.jp/contests/abc176/submissions/16127778
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
        var hwm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwm[0];
        var w = hwm[1];
        var m = hwm[2];
        int[] countY = new int[h + 1];
        int[] countX = new int[w + 1];
        HashSet<(int, int)> set = new HashSet<(int, int)>();
        for (int i = 0; i < m; i++)
        {
            var yx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var y = yx[0];
            var x = yx[1];
            countY[y]++;
            countX[x]++;
            set.Add((y, x));
        }
        var top2Y = countY.Select((elem, ind) => (elem, ind)).GroupBy(x => x.elem, x => x.ind).OrderByDescending(x => x.Key).ToArray();
        var top2X = countX.Select((elem, ind) => (elem, ind)).GroupBy(x => x.elem, x => x.ind).OrderByDescending(x => x.Key).ToArray();
        var fY = (top2Y[0].Key, top2Y[0].ToArray());
        var fX = (top2X[0].Key, top2X[0].ToArray());
        if (m < fY.Item2.LongLength * fX.Item2.LongLength)
        {
            Console.WriteLine(fY.Key + fX.Key);
            return;
        }
        foreach (var y in fY.Item2)
        {
            foreach (var x in fX.Item2)
            {
                if (!set.Contains((y, x)))
                {
                    Console.WriteLine(fY.Key + fX.Key);
                    return;
                }
            }
        }
        Console.WriteLine(fY.Key + fX.Key - 1);
    }
}
