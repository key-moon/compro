// detail: https://atcoder.jp/contests/abc192/submissions/20310481
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        for (int i = 0; i < k; i++)
        {
            var g1 = int.Parse(string.Join("", n.ToString().OrderByDescending(x => x)));
            var g2 = int.Parse(string.Join("", n.ToString().OrderBy(x => x)));
            n = g1 - g2;
        }
        Console.WriteLine(n);
    }
}