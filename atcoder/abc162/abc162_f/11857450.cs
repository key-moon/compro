// detail: https://atcoder.jp/contests/abc162/submissions/11857450
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
            //max(xoxoxox, oxoxoxx, xxoxoxo)
            var sum = accumEven.SkipLast(1).Last();
            var res = sum;
            var tailSum = 0L;
            var tailMax = 0L;
            for (int i = accumEven.Length - 4; i >= 0; i -= 2)
            {
                sum -= a[i]; sum += a[i + 1];
                tailSum += a[i + 2]; tailSum -= a[i + 1];
                tailMax = Max(tailMax, tailSum);
                res = Max(res, sum + tailMax);
            }
            Console.WriteLine(res);
            return;
        }
    }
}
