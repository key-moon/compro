// detail: https://codeforces.com/contest/660/submission/98798933
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
        long[] ps = new[]
        {
            998244353L,
            999999937L,
            999999929L,
        };
        List<long> res = new List<long>() { a[0] };
        int cnt = 0;
        for (int i = 1; i < a.Length; i++)
        {
            if (GCD(res.Last(), a[i]) != 1)
            {
                var insert = ps.Except(new[] { res.Last(), a[i] }).First();
                res.Add(insert);
                cnt++;
            }
            res.Add(a[i]);
        }
        Console.WriteLine(cnt);
        Console.WriteLine(string.Join(" ", res));
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
