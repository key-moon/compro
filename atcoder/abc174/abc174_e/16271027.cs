// detail: https://atcoder.jp/contests/abc174/submissions/16271027
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        int valid = int.MaxValue / 2;
        int invalid = 0;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;

            if (a.Sum(x => (x + mid - 1) / mid) <= k + n) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(valid);
    }
}