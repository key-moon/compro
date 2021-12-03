// detail: https://atcoder.jp/contests/abc230/submissions/27659671
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
        var n = long.Parse(Console.ReadLine());
        long res = 0;
        // smallest res s.t. n / res <= i
        long Calc(long i)
        {
            long valid = long.MaxValue / 2;
            long invalid = 0;
            while (valid - invalid > 1)
            {
                var mid = (valid + invalid) / 2;
                if (n / mid <= i) valid = mid;
                else invalid = mid;
            }
            return valid;
        }
        for (long i = 1; i * i <= n; i++)
        {
            res += n / i;
            if (n / i == i) continue;
            long lowest = Calc(i);
            long highest = Calc(i - 1);
            while (i <= n / highest) highest++;
            while (n / highest < i) highest--;
            Trace.Assert(n / lowest == i);
            Trace.Assert(n / highest == i);
            res += (highest - lowest + 1) * i;
        }

        Console.WriteLine(res);
    }
}