// detail: https://atcoder.jp/contests/abc164/submissions/12347817
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
        var s = Console.ReadLine().Select(x => x - '0').ToArray();
        int[] count = new int[2019];
        long res = 0;
        int cur = 0;
        count[cur]++;
        foreach (var c in s)
        {
            cur = (cur * 10 + c) % 2019;
            res += count[cur];
            count[cur]++;
            int[] newCount = new int[2019];
            for (int i = 0; i < count.Length; i++)
            {
                newCount[i * 10 % 2019] += count[i];
            }
            count = newCount;
        }
        Console.WriteLine(res);
    }
}