// detail: https://codeforces.com/contest/1456/submission/99845695
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        var npk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = npk[0];
        var p = npk[1];
        var k = npk[2];
        var s = Console.ReadLine().Select(x => x == '1').ToArray();
        var xy = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var x = xy[0];
        var y = xy[1];
        long res = long.MaxValue;
        for (int i = 0; i < k; i++)
        {
            var start = i + p - 1;
            if (n <= start) continue;
            long curCost = i * y;
            for (int j = start; j < n; j += k)
            {
                if (!s[j]) curCost += x;
            }
            res = Min(res, curCost);
            while (true)
            {
                if (n <= start + k) break;
                if (!s[start]) curCost -= x;
                start += k;
                curCost += k * y;
                res = Min(res, curCost);
            }
        }
        Console.WriteLine(res);
    }
}
