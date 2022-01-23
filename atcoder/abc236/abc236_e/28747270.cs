// detail: https://atcoder.jp/contests/abc236/submissions/28747270
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
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();

        {
            double valid = 0, invalid = int.MaxValue;
            for (int _ = 0; _ < 100; _++)
            {
                var mid = (invalid + valid) / 2;

                double[] maxSum = Enumerable.Repeat((double)long.MinValue, n).ToArray();
                maxSum[0] = a[0] - mid;
                maxSum[1] = a[1] - mid + (0 < maxSum[0] ? maxSum[0] : 0);
                for (int i = 2; i < n; i++)
                {
                    maxSum[i] = Max(maxSum[i - 1], maxSum[i - 2]);
                    maxSum[i] += a[i] - mid;
                }
                if (0 <= Max(maxSum[^1], maxSum[^2])) valid = mid;
                else invalid = mid;
            }
            Console.WriteLine(valid);
        }

        {
            long valid = 0, invalid = int.MaxValue;
            while (invalid - valid > 1)
            {
                var mid = (invalid + valid) / 2;

                int[] ds = Enumerable.Repeat(int.MaxValue, n).ToArray();
                ds[0] = a[0] < mid ? 1 : -1;
                ds[1] = (a[1] < mid ? 1 : -1) + (ds[0] < 0 ? ds[0] : 0);
                for (int i = 2; i < n; i++)
                {
                    ds[i] = Min(ds[i - 1], ds[i - 2]);
                    ds[i] += a[i] < mid ? 1 : -1;
                }
                if (Min(ds[^1], ds[^2]) < 0) valid = mid;
                else invalid = mid;
            }
            Console.WriteLine(valid);
        }
    }
}