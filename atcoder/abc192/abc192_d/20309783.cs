// detail: https://atcoder.jp/contests/abc192/submissions/20309783
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
        var x = Console.ReadLine();
        var m = long.Parse(Console.ReadLine());
        var lb = x.Max(x => x - '0') + 1;
        if (x.Length == 1)
        {
            Console.WriteLine(int.Parse(x) <= m ? 1 : 0);
            return;
        }
        BigInteger valid = lb - 1;
        BigInteger invalid = m + 1;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;
            BigInteger val = 0;
            BigInteger pow = 1;
            foreach (var c in x.Reverse())
            {
                var dig = c - '0';
                val += pow * dig;
                if (m < val) break;
                pow *= mid;
            }
            if (val <= m) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine(Max(0, (long)(invalid - lb)));
    }
}