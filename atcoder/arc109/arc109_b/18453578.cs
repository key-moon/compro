// detail: https://atcoder.jp/contests/arc109/submissions/18453578
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
            long n = long.Parse(Console.ReadLine());
            long valid = 0;
            long invalid = int.MaxValue;
            while (invalid - valid > 1)
            {
                var mid = (valid + invalid) / 2;
                if (mid * (mid + 1) / 2 <= n + 1) valid = mid;
                else invalid = mid;
            }
            Console.WriteLine(n + 1 - valid);
        }
    }
}