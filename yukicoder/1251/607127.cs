// detail: https://yukicoder.me/submissions/607127
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long F(long X) => a.Zip(b, (a, b) => Abs(X - a) * b).Sum();
        long valid = (long)-1e6;
        long invalid = (long)1e6;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            if (F(mid) - F(mid + 1) >= 1) valid = mid;
            else invalid = mid;
        }
        Console.WriteLine($"{invalid} {F(invalid)}");
    }
}