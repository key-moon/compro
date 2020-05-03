// detail: https://atcoder.jp/contests/abc166/submissions/12732343
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = 0L;
        var mark = new long[n];
        for (int i = 0; i < a.Length; i++)
        {
            if (0 <= i - a[i]) res += mark[i - a[i]];
            if (i + a[i] < n) mark[i + a[i]]++;
        }
        Console.WriteLine(res);
    }
}