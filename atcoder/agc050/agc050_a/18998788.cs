// detail: https://atcoder.jp/contests/agc050/submissions/18998788
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
        if (n == 1)
        {
            Console.WriteLine("1 1");
            return;
        }
        List<int[]> res = null;
        res = Enumerable.Repeat(0, n + 1).Select(_ => new int[2]).ToList();

        for (int i = 1; i <= n; i++)
        {
            var a = i << 1;
            var b = (i << 1) | 1;
            int Proceed(int i)
            {
                int mask = (1 << 30) - 1;
                while (n < (i & mask)) mask >>= 1;
                return (i & mask) == 0 ? 2 : (i & mask);
            }
            res[i][0] = Proceed(a);
            res[i][1] = Proceed(b);
        }

        Console.WriteLine(string.Join("\n", res.Skip(1).Select(x => string.Join(" ", x))));
    }
}
