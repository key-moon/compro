// detail: https://atcoder.jp/contests/abc113/submissions/16279375
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
        int n = int.Parse(Console.ReadLine());
        var ta = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var t = ta[0];
        var a = ta[1];
        var h = Console.ReadLine().Split().Select(int.Parse).ToArray();
        double min = double.MaxValue;
        int ind = -1;
        for (int i = 0; i < h.Length; i++)
        {
            var tmp = t - h[i] * 0.006;
            var diff = Abs(tmp - a);
            if (diff >= min) continue;
            min = diff;
            ind = i;
        }
        Console.WriteLine(ind + 1);
    }
}