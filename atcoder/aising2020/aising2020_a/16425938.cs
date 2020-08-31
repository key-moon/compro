// detail: https://atcoder.jp/contests/aising2020/submissions/16425938
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
        var lrd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var l = lrd[0];
        var r = lrd[1];
        var d = lrd[2];
        int res = 0;
        for (int i = l; i <= r; i++)
            if (i % d == 0) res++;
        Console.WriteLine(res);
    }
}
