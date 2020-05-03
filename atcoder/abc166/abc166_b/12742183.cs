// detail: https://atcoder.jp/contests/abc166/submissions/12742183
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
        var (n, k) = (nk[0], nk[1]);
        var snukes = Enumerable.Range(1, n);
        for (int i = 0; i < k; i++)
        {
            int.Parse(Console.ReadLine());
            snukes = snukes.Except(Console.ReadLine().Split().Select(int.Parse).ToArray());
        }
        Console.WriteLine(snukes.Count());
    }
}