// detail: https://atcoder.jp/contests/code-festival-2015-quala/submissions/16428779
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
        var nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nt[0];
        var t = nt[1];
        var ab = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).OrderByDescending(x => x[0] - x[1]).ToArray();
        var sum = ab.Sum(x => x[0]) - t;
        var count = ab.TakeWhile(x => (x[0] - x[1]) + (sum -= (x[0] - x[1])) > 0).Count();

        Console.WriteLine(sum > 0 ? -1 : count);
    }
}