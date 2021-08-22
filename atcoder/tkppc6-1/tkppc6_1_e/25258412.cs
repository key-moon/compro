// detail: https://atcoder.jp/contests/tkppc6-1/submissions/25258412
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var sorteda = a.OrderByDescending(x => x).ToArray();
        long res = 0;
        for (int i = 31; i >= 0; i--)
        {
            var cnt = sorteda.Count(x => (x >> i & 1) != 0);
            if (2 <= cnt)
            {
                sorteda = sorteda.Where(x => (x >> i & 1) != 0).ToArray();
                res += (1L << i) * 2;
            }
        }
        Console.WriteLine(res);
    }
}
