// detail: https://atcoder.jp/contests/abc036/submissions/21551765
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
        var mat = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().ToArray()).ToArray();
        Console.WriteLine(string.Join("\n", Enumerable.Range(0, n).Select(j => string.Join("", Enumerable.Range(0, n).Reverse().Select(i => mat[i][j])))));
    }
}