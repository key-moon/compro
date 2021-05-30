// detail: https://atcoder.jp/contests/abc203/submissions/23074193
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
        var kn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = kn[0];
        var k = kn[1];
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int valid = int.MaxValue / 2;
        int invalid = -1;
        while (valid - invalid > 1)
        {
            var mid = (valid + invalid) / 2;
            var accum = Enumerable.Repeat(0, n + 1).Select(_ => new long[n + 1]).ToArray();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    accum[i + 1][j + 1] = accum[i][j + 1] + accum[i + 1][j] - accum[i][j];
                    if (a[i][j] <= mid) accum[i + 1][j + 1]++;
                }
            }
            for (int i = k; i <= n; i++)
            {
                for (int j = k; j <= n; j++)
                {
                    var cnt = accum[i][j] - accum[i - k][j] - accum[i][j - k] + accum[i - k][j - k];
                    if (k * k <= cnt * 2)
                    {
                        valid = mid;
                        goto end;
                    }
                }
            }
            invalid = mid;
            end:;
        }
        Console.WriteLine(valid);
    }
}