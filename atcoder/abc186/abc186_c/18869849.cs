// detail: https://atcoder.jp/contests/abc186/submissions/18869849
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
        int res = 0;
        for (int i = 1; i <= n; i++)
        {
            if (Convert.ToString(i, 8).Concat(i.ToString()).Contains('7')) continue;
            res++;
        }
        Console.WriteLine(res);
    }
}