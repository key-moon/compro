// detail: https://atcoder.jp/contests/m-solutions2020/submissions/16428258
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
        long current = 1000;
        for (int i = 1; i < n; i++)
        {
            if (a[i - 1] > a[i]) continue;
            current = (current / a[i - 1]) * a[i] + current % a[i - 1];
        }
        Console.WriteLine(current);
    }
}
