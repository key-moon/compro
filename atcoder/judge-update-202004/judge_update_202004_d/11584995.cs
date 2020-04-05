// detail: https://atcoder.jp/contests/judge-update-202004/submissions/11584995
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var (n, q) = (nq[0], nq[1]);
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var s = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var accum = new long[a.Length + 1];
        for (int i = 0; i < a.Length; i++) accum[i + 1] = GCD(accum[i], a[i]);
        foreach (var item in s)
        {
            if (GCD(item, accum.Last()) != 1)
            {
                Console.WriteLine(GCD(item, accum.Last()));
                continue;
            }
            int valid = accum.Length - 1;
            int invalid = 0;
            while (valid - invalid > 1)
            {
                var mid = (valid + invalid) / 2;
                var gcd = GCD(item, accum[mid]);
                if (gcd == 1) valid = mid;
                else invalid = mid;
            }
            Console.WriteLine(valid);
        }
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }
}
