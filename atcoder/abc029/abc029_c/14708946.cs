// detail: https://atcoder.jp/contests/abc029/submissions/14708946
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

        Console.WriteLine(string.Join("\n", Solve(int.Parse(Console.ReadLine()))));
    }

    static char[] abc = new[] { 'a', 'b', 'c' };
    public static IEnumerable<string> Solve(int n)
    {
        if (n == 0) return new string[] { "" };
        return Solve(n - 1).SelectMany(x => abc.Select(y => x + y));
    }
}