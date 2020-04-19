// detail: https://atcoder.jp/contests/abc163/submissions/12080034
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
        var a = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        int[] res = new int[n];
        for (int i = a.Length - 1; i >= 0; i--)
        {
            res[a[i]] += 1;
        }
        Console.WriteLine(string.Join("\n", res));
    }
}