// detail: https://codeforces.com/contest/1114/submission/49721984
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        long[] nb = Console.ReadLine().Split().Select(long.Parse).ToArray();
        //えっと、つまり素因数分解して約数の数を数えればOK
        var factors = Factors(nb[1]);
        long res = long.MaxValue;
        foreach (var factor in factors.GroupBy(x => x))
        {
            long current = factor.Key;
            long count = 0;
            double limit = Sqrt(nb[0] + 100);
            while (nb[0] >= current)
            {
                count += nb[0] / current;
                if (((double)current * (double)factor.Key) >= nb[0] + 114514) break;
                current *= factor.Key;
            }
            res = Min(res, count / factor.Count());
        }
        Console.WriteLine(res);
    }


    static long[] Factors(long n)
    {
        List<long> res = new List<long>();
        while (n % 2 == 0)
        {
            res.Add(2);
            n /= 2;
        }
        long i = 3;
        double ub = Sqrt(n);
        while (i <= ub + 1)
        {
            if (n % i == 0)
            {
                res.Add(i);
                n /= i;
            }
            else
            {
                i += 2;
            }
        }
        if (n != 1) res.Add(n);
        return res.ToArray();
    }
}
