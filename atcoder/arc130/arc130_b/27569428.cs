// detail: https://atcoder.jp/contests/arc130/submissions/27569428
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
        var hwcq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwcq[0];
        var w = hwcq[1];
        var c = hwcq[2];
        var q = hwcq[3];
        long[] cols = new long[c];

        HashSet<int> colordRow = new HashSet<int>();
        HashSet<int> colordCol = new HashSet<int>();
        var qs = Enumerable.Repeat(0, q).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        foreach (var query in qs.Reverse())
        {
            var t = query[0];
            var n = query[1];
            var col = query[2] - 1;

            var set = t == 1 ? colordRow : colordCol;
            if (set.Contains(n)) continue;
            set.Add(n);
            cols[col] += t == 1 ? w : h;
            if (t == 1) h--;
            if (t == 2) w--;
        }

        Console.WriteLine(string.Join(" ", cols));
    }
}