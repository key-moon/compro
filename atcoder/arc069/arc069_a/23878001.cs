// detail: https://atcoder.jp/contests/arc069/submissions/23878001
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
        var nm = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var s = nm[0];
        var c = nm[1];
        long valid = 0, invalid = long.MaxValue / 2;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            var needS = mid;
            var needC = mid * 2;
            needS -= Min(s, needS);
            var useCForS = Min(needS * 2, c);
            if (c - useCForS >= needC) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }
}