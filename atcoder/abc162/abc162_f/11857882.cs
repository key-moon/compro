// detail: https://atcoder.jp/contests/abc162/submissions/11857882
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var accumOdd = new long[n + 1];
        var accumEven = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                accumEven[i + 1] = accumEven[i] + a[i];
                accumOdd[i + 1] = accumOdd[i];
            }
            else
            {
                accumEven[i + 1] = accumEven[i];
                accumOdd[i + 1] = accumOdd[i] + a[i];
            }
        }
        if (n % 2 == 0)
        {
            var res = Max(accumOdd.Last(), accumEven.Last());
            var sum = 0L;
            for (int i = accumEven.Length - 3; i >= 0; i -= 2)
            {
                sum += a[i + 1];
                res = Max(res, accumEven[i] + sum);
            }
            Console.WriteLine(res);
            return;
        }
        else
        {
            var sum = 0L;
            for (int i = 0; i < a.Length - 1; i += 2) sum += a[i];
            var res = sum;
            var tailDiff = 0L;
            var tailDiffMax = 0L;
            for (int i = a.Length - 3; i >= 0; i -= 2)
            {
                sum -= a[i]; sum += a[i + 1];
                tailDiff += a[i + 2]; tailDiff -= a[i + 1];
                tailDiffMax = Max(tailDiffMax, tailDiff);
                res = Max(res, sum + tailDiffMax);
            }
            Console.WriteLine(res);
            return;
        }
    }
}
