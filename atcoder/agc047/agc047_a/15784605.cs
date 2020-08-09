// detail: https://atcoder.jp/contests/agc047/submissions/15784605
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
        long res = 0;
        int[,] cnts = new int[30, 30];
        for (int _ = 0; _ < n; _++)
        {
            var s = Console.ReadLine();
            long a, b;
            var ind = s.IndexOf('.');
            if (ind != -1)
            {
                a = int.Parse(s.Substring(0, ind));
                b = int.Parse(s.Substring(ind + 1).PadRight(9, '0'));
            }
            else
            {
                a = int.Parse(s);
                b = 0;
            }
            var val = a * 1000000000 + b;
            var (cnta, cntb) = GetCnt(val);
            cnts[Min(cnta, 18), Min(cntb, 18)]++;
            //Console.WriteLine($"{Min(cnta, 18)} {Min(cntb, 18)}");
            if (18 <= cnta + cnta && 18 <= cntb + cntb) res--;
        }
        //Console.WriteLine(res);
        for (int i = 0; i <= 18; i++)
        {
            for (int j = 0; j <= 18; j++)
            {
                long curres = 0;
                for (int k = 18 - i; k <= 18; k++)
                {
                    for (int l = 18 - j; l <= 18; l++)
                    {
                        curres += cnts[k, l];
                    }
                }
                res += curres * cnts[i, j];
            }
        }
        //Console.WriteLine(res);
        res /= 2;
        Console.WriteLine(res);
    }

    static (int, int) GetCnt(long n)
    {
        int cnt2 = 0;
        int cnt5 = 0;
        while ((n & 1) == 0)
        {
            n >>= 1;
            cnt2++;
        }
        while (n % 5 == 0)
        {
            n /= 5;
            cnt5++;
        }
        return (cnt2, cnt5);
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
