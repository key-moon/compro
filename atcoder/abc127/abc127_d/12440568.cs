// detail: https://atcoder.jp/contests/abc127/submissions/12440568
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

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();

        var ptr = 0;
        foreach (var query in Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderByDescending(x => x[1]))
        {
            var b = query[0];
            var c = query[1];
            for (int i = 0; i < b && ptr < a.Length && a[ptr] < c; i++, ptr++) a[ptr] = c;
        }
        Console.WriteLine(a.Sum());
    }
}
