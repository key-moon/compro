// detail: https://atcoder.jp/contests/abc161/submissions/11520805
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
        HashSet<long> reses = new HashSet<long>();
        long res = 0;
        for (long b = 2; b * b <= n; b++)
        {
            for (long pow = 1; n % pow == 0; pow *= b)
            {
                if (((n / pow) - 1) % b == 0)
                {
                    reses.Add(b);
                    res++;
                    break;
                }
            }
        }
        //b^n(mb+1)
        res++;//k=6
        long i;
        for (i = 1; i * i <= n - 1; i++)
        {
            if ((n - 1) % i != 0) continue;
            reses.Add((n - 1) / i);
            reses.Add(i);
            res += 2;
        }
        Console.WriteLine(reses.Count);
    }
}