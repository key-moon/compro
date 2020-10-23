// detail: https://yukicoder.me/submissions/570765
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        int n = int.Parse(Console.ReadLine());
        long[][] pts = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray();

        int res = 0;
        HashSet<int> remain = new HashSet<int>(Enumerable.Range(0, n));
        foreach (var item in Enumerable.Range(0, n - 1).SelectMany(x => Enumerable.Range(x + 1, n - x - 1).Select(y => new Tuple<int, int>(x, y))).OrderBy(x => GetDist(pts[x.Item1], pts[x.Item2])))
        {
            var i = item.Item1;
            var j = item.Item2;
            if (remain.Contains(i) && remain.Contains(j))
            {
                if (i != 0) remain.Remove(i);
                else res++;
                remain.Remove(j);
            }
        }

        Console.WriteLine(res);
    }

    static long GetDist(long[] a, long[] b)
    {
        var dy = a[0] - b[0];
        var dx = a[1] - b[1];
        return dy * dy + dx * dx;
    }
}