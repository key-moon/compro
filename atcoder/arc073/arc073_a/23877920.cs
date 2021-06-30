// detail: https://atcoder.jp/contests/arc073/submissions/23877920
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
        var times = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        var from = times[0];
        void Proceed(int newTime)
        {
            res += Min(newTime - from, t);
            from = newTime;
        }
        foreach (var time in times.Skip(1)) Proceed(time);
        Proceed(int.MaxValue);
        Console.WriteLine(res);
    }
}

