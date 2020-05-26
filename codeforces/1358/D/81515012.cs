// detail: https://codeforces.com/contest/1358/submission/81515012
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
        var nx = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nx[0];
        var x = nx[1];
        var d = Console.ReadLine().Split().Select(int.Parse).ToArray();


        long curCount = 0;

        int lastIncompleteMonth = 0;
        long unusedDayCount = 0;

        {
            var remain = x;
            for (int i = d.Length - 1; i >= 0; i--)
            {
                var item = d[i];

                curCount += Calc(item);
                remain -= item;
                if (remain <= 0)
                {
                    lastIncompleteMonth = i;
                    break;
                }
            }
            unusedDayCount = -remain;
            curCount -= Calc(unusedDayCount);
        }

        long max = curCount;

        for (int i = 0; i < d.Length; i++)
        {
            curCount += Calc(d[i]);
            curCount -= Calc(d[lastIncompleteMonth]) - Calc(unusedDayCount);
            long curDayCount = x - (d[lastIncompleteMonth] - unusedDayCount) + d[i];
            while (x < curDayCount)
            {
                lastIncompleteMonth++;
                if (lastIncompleteMonth == n) lastIncompleteMonth = 0;
                curCount -= Calc(d[lastIncompleteMonth]);
                curDayCount -= d[lastIncompleteMonth];
            }
            var usedDay = x - curDayCount;
            unusedDayCount = d[lastIncompleteMonth] - usedDay;
            curCount += Calc(d[lastIncompleteMonth]) - Calc(unusedDayCount);
            max = Max(max, curCount);
        }

        Console.WriteLine(max);
    }

    public static long Calc(long hoge) => hoge * (hoge + 1) / 2;
}