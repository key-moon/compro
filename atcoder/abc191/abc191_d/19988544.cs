// detail: https://atcoder.jp/contests/abc191/submissions/19988544
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
        checked
        {
            const long mul = 10000;
            var xyr = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            long r = (long)Round(xyr[2] * mul);
            long offset = (r / mul * mul) + mul * 100;
            long x = ((long)Round(xyr[0] * mul) + mul * 100000L) % mul + offset;
            long y = ((long)Round(xyr[1] * mul) + mul * 100000L) % mul + offset;
            long lower = (y - r) / mul * mul - mul * 10;
            long upper = (y + r) / mul * mul + mul * 10;
            long res = 0;
            for (long i = lower; i <= upper; i += mul)
            {
                if (r * r - (i - y) * (i - y) < 0) continue;
                long valid1, invalid1;
                invalid1 = x + r + 1;
                valid1 = x;
                while (invalid1 - valid1 > 1)
                {
                    var mid = (valid1 + invalid1) / 2;
                    if (0 <= r * r - (i - y) * (i - y) - (mid - x) * (mid - x)) valid1 = mid;
                    else invalid1 = mid;
                }
                long valid2, invalid2;
                invalid2 = x - r - 1;
                valid2 = x;
                while (valid2 - invalid2 > 1)
                {
                    var mid = (valid2 + invalid2) / 2;
                    if (0 <= r * r - (i - y) * (i - y) - (mid - x) * (mid - x)) valid2 = mid;
                    else invalid2 = mid;
                }
                res += Max(valid1 / mul - invalid2 / mul, 0);
            }
            Console.WriteLine(res);
        }
    }
}
