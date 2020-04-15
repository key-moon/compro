// detail: https://atcoder.jp/contests/abc161/submissions/11955486
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
        var n = long.Parse(Console.ReadLine());
        if (n == 2)
        {
            Console.WriteLine(1);
            return;
        }
        HashSet<long> res = new HashSet<long>();
        {
            res.Add(n - 1);
            long i;
            for (i = 2; i * i < n - 1; i++)
            {
                if ((n - 1) % i != 0) continue;
                res.Add(i);
                res.Add((n - 1) / i);
            }
            if (i * i == n - 1) res.Add(i);
        }
        {
            res.Add(n);

            long i;
            for (i = 2; i * i < n; i++)
            {
                if (n % i != 0) continue;
                if (isValid(i, n)) res.Add(i);
                if (isValid(n / i, n)) res.Add(n / i);
            }
            if (i * i == n)
                if (isValid(i, n)) res.Add(i);
        }
        Console.WriteLine(res.Count);
    }
    static bool isValid(long i, long n)
    {
        var tmp = n;
        while (tmp % i == 0) tmp /= i;
        return (tmp - 1) % i == 0;
    }
}
