// detail: https://atcoder.jp/contests/abc181/submissions/17815717
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var h = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        var w = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();

        if (n == 1)
        {
            Console.WriteLine(w.Min(x => Abs(h[0] - x)));
            return;
        }

        var pairFromFront = new long[n];
        pairFromFront[1] = Abs(h[0] - h[1]);
        for (int i = 3; i < n; i += 2)
            pairFromFront[i] = pairFromFront[i - 2] + Abs(h[i - 1] - h[i]);
        for (int i = 2; i < n; i += 2)
            pairFromFront[i] = pairFromFront[i - 1];

        var pairFromBack = new long[n];
        pairFromBack[n - 2] = Abs(h[n - 2] - h[n - 1]);
        for (int i = n - 4; i >= 0; i -= 2)
            pairFromBack[i] = pairFromBack[i + 2] + Abs(h[i + 1] - h[i]);
        for (int i = n - 3; i >= 0; i -= 2)
            pairFromBack[i] = pairFromBack[i + 1];

        long min = long.MaxValue;
        foreach (var item in w)
        {
            var ind = Array.BinarySearch(h, item);
            if (ind < 0) ind = ~ind;
            var pairTo = ind / 2 * 2;
            var cur = pairFromFront[pairTo] + pairFromBack[pairTo] + Abs(item - h[pairTo]);
            min = Min(min, cur);
        }

        Console.WriteLine(min);
    }
}