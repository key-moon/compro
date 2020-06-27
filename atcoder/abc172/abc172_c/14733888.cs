// detail: https://atcoder.jp/contests/abc172/submissions/14733888
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
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmk[0];
        var m = nmk[1];
        var k = nmk[2];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int aCount;
        int aSum = 0;
        for (aCount = 0; true; aCount++)
        {
            if (aCount >= a.Length || aSum + a[aCount] > k) break;
            aSum += a[aCount];
        }
        var res = aCount;
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var curSum = 0;
        for (int i = 0; i < b.Length; i++)
        {
            curSum += b[i];
            if (curSum > k) break;
            while (aSum + curSum > k)
            {
                aCount--;
                aSum -= a[aCount];
            }
            res = Max(res, aCount + i + 1);
        }
        Console.WriteLine(res);
    }
}
