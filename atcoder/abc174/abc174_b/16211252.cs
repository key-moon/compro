// detail: https://atcoder.jp/contests/abc174/submissions/16211252
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
        var nd = Console.ReadLine().Split().Select(long.Parse).ToArray();
        int res = 0;
        for (int i = 0; i < nd[0]; i++)
        {
            var xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
            if (xy[0] * xy[0] + xy[1] * xy[1] <= nd[1] * nd[1]) res++;
        }
        Console.WriteLine(res);
    }
}