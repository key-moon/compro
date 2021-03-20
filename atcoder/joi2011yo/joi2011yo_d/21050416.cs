// detail: https://atcoder.jp/contests/joi2011yo/submissions/21050416
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long[] cnt = new long[21];
        cnt[a.First()] = 1;
        foreach (var item in a.Skip(1).SkipLast(1))
        {
            long[] newcnt = new long[21];
            for (int i = 0; i < cnt.Length; i++)
            {
                if (0 <= i - item) newcnt[i - item] += cnt[i];
                if (i + item <= 20) newcnt[i + item] += cnt[i];
            }
            cnt = newcnt;
        }
        Console.WriteLine(cnt[a.Last()]);
    }
}