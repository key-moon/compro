// detail: https://atcoder.jp/contests/code-festival-2014-quala/submissions/14115230
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
        var ak = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = ak[0];
        var astr = ak[0].ToString();
        var k = (int)ak[1];

        var res = long.MaxValue;
        if (a <= 100000)
        {
            for (int i = 0; i <= 200000; i++)
            {
                if (i.ToString().Distinct().Count() > k) continue;
                res = Min(res, Abs(a - i));
            }

            Console.WriteLine(res);
            return;
        }

        for (int i = 0; i < (1 << 10); i++)
        {
            List<int> canUse = new List<int>();
            for (int j = 0; j < 10; j++)
            {
                if ((i >> j & 1) == 1) canUse.Add(j);
            }
            if (canUse.Count == k) res = Min(res, Min(Solve(astr, canUse), Solve('0' + astr, canUse)));
        }
        Console.WriteLine(res);
    }

    public static long Solve(string a, List<int> canUse)
    {
        bool canExactly = true;
        long high = -1;
        long exactly = 0;
        long low = 0;
        foreach (var val in a.Select(x => x - '0'))
        {
            long newHigh;
            long newLow;
            if (canExactly)
            {
                var larger = canUse.Where(x => val <= x).DefaultIfEmpty(-1).Min();
                if (larger != -1) newHigh = exactly * 10 + larger;
                else newHigh = -1;

                var smaller = canUse.Where(x => x <= val).DefaultIfEmpty(10).Max();
                if (smaller != 10) newLow = exactly * 10 + smaller;
                else newLow = 0;
                canExactly &= canUse.Contains(val);
            }
            else
            {
                newHigh = high == -1 ? -1 : high * 10 + canUse.Min();
                newLow = low == -1 ? -1 : low * 10 + canUse.Max();
            }
            exactly = exactly * 10 + val;
            high = newHigh;
            low = newLow;
        }
        return Min((high == -1 ? long.MaxValue : high - exactly), (low == -1 ? long.MaxValue : Abs(exactly - low)));
    }
}
