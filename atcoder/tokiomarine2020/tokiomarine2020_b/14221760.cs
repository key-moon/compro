// detail: https://atcoder.jp/contests/tokiomarine2020/submissions/14221760
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
        var av = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var bw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var t = long.Parse(Console.ReadLine());

        Console.WriteLine((av[1] - bw[1]) * t >= Abs(av[0] - bw[0]) ? "YES" : "NO");
    }
}