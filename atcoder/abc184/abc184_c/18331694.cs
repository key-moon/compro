// detail: https://atcoder.jp/contests/abc184/submissions/18331694
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
        var rc1 = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var rc2 = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var (r1, c1) = (rc1[0], rc1[1]);
        var (r2, c2) = (rc2[0], rc2[1]);
        bool Movable((long, long) rc1, (long, long) rc2)
        {
            var (r1, c1) = rc1;
            var (r2, c2) = rc2;
            var r = Abs(r2 - r1);
            var c = Abs(c2 - c1);
            if (r + c <= 3) return true;
            if (r == c) return true;
            return false;
        }
        var res = 3;
        if ((Abs(r1 - r2) + Abs(c1 - c2)) % 2 == 0) res = 2;
        for (long r = r1 - 10; r <= r1 + 10; r++)
        {
            for (long c = c1 - 10; c <= c1 + 10; c++)
            {
                if (Movable((r1, c1), (r, c)) && Movable((r, c), (r2, c2))) res = 2;
            }
        }
        if (Movable((r1, c1), (r2, c2))) res = 1;
        if (r1 == r2 && c1 == c2) res = 0;
        Console.WriteLine(res);
    }
}