// detail: https://atcoder.jp/contests/zone2021/submissions/22200519
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
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int valid = 0;
        int invalid = int.MaxValue / 2;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            var arr = a.Select(x =>
            {
                int res = 0;
                for (int i = 0; i < x.Length; i++)
                    if (mid <= x[i])
                        res += 1 << i;
                return res;
            }).Distinct().ToArray();
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                    for (int k = 0; k < arr.Length; k++)
                        if ((arr[i] | arr[j] | arr[k]) == (1 << 5) - 1)
                        {
                            valid = mid;
                            goto end;
                        }
            invalid = mid;
            end:;
        }
        Console.WriteLine(valid);
    }
}
