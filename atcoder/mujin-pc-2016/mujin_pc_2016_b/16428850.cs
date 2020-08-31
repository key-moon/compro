// detail: https://atcoder.jp/contests/mujin-pc-2016/submissions/16428850
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
        var arms = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var outer = arms.Sum();
        var inner = Max(arms.Max() * 2 - outer, 0);
        Console.WriteLine(outer * outer * PI - inner * inner * PI);
    }
}