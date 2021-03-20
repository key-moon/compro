// detail: https://atcoder.jp/contests/abc196/submissions/21077018
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
        long lower = long.MinValue / 2;
        long upper = long.MaxValue / 2;
        long offset = 0;
        for (int i = 0; i < n; i++)
        {
            var at = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = at[0];
            var t = at[1];
            if (t == 1)
            {
                lower += a;
                upper += a;
                offset += a;
            }
            if (t == 2)
            {
                lower = Max(lower, a);
                upper = Max(upper, a);

            }
            if (t == 3)
            {
                lower = Min(lower, a);
                upper = Min(upper, a);
            }
        }
        int q = int.Parse(Console.ReadLine());
        foreach (var item in Console.ReadLine().Split().Select(int.Parse))
        {
            Console.WriteLine(Clamp(item + offset, lower, upper));
        }
    }
}