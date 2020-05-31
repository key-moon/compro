// detail: https://atcoder.jp/contests/abc169/submissions/13796029
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
        long n = long.Parse(Console.ReadLine());
        long res = 0;
        foreach (var item in PrimeFactors(n).GroupBy(x => x))
        {
           var count = item.Count();
            for (int i = 1; i <= count; i++)
            {
                res++;
                count -= i;
            }
        }
        Console.WriteLine(res);
    }


    static IEnumerable<long> PrimeFactors(long n)
    {
        while ((n & 1) == 0)
        {
            n >>= 1;
            yield return 2;
        }
        for (long i = 3; i * i <= n; i += 2)
        {
            while (n % i == 0)
            {
                n /= i;
                yield return i;
            }
        }
        if (n != 1) yield return n;
    }
}
