// detail: https://atcoder.jp/contests/arc131/submissions/27712779
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
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        string res;
        if (b % 2 == 0)
        {
            res = $"{a}{b / 2}";
        }
        else
        {
            res = $"{b / 2}5{a}";
        }
        res = res.TrimStart('0');
        Trace.Assert(res.Contains(a.ToString()));
        Trace.Assert((
        long.Parse(res) * 2).ToString().Contains(b.ToString()));
        Trace.Assert(long.Parse(res) < 1e18);
        Console.WriteLine(res);
    }
}