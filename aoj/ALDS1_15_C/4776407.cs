// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_15_C/judge/4776407/C#
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
        var curEnd = -1;
        foreach (var item in Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderBy(x => x[1]))
        {
            var start = item[0];
            var end = item[1];
            if (start <= curEnd) continue;
            res++;
            curEnd = end;
        }
        Console.WriteLine(res);
    }
}

