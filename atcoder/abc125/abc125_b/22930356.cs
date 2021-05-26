// detail: https://atcoder.jp/contests/abc125/submissions/22930356
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
        var v = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var c = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(v.Zip(c, (x, y) => x - y).Where(x => 0 <= x).Sum());
    }
}