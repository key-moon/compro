// detail: https://atcoder.jp/contests/abc170/submissions/14291531
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
        var xn = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var s = Console.ReadLine();
        if (s.Length == 0) s = "11111111";
        Console.WriteLine(Enumerable.Range(-150, 300).Except(s.Split().Select(int.Parse)).OrderBy(x => Abs(xn[0] - x)).ThenBy(x => x).First());
    }
}