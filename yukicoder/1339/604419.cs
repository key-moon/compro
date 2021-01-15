// detail: https://yukicoder.me/submissions/604419
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            long n = int.Parse(Console.ReadLine());
            while (n % 2 == 0) n /= 2;
            while (n % 5 == 0) n /= 5;
            long res = n == 1 ? 1 : long.MaxValue;
            var totient = Totient(n);
            for (int j = 1; j * j <= totient; j++)
            {
                if (totient % j != 0) continue;
                if (Power(10, j, n) == 1) res = Min(res, j);
                if (Power(10, totient / j, n) == 1) res = Min(res, totient / j);
            }
            Console.WriteLine(res);
        }

        static long Power(long n, long m, long mod)
        {
            long pow = n;
            long res = 1;
            while (m > 0)
            {
                if ((m & 1) == 1) res = (pow * res) % mod;
                pow = (pow * pow) % mod;
                m >>= 1;
            }
            return res;
        }
    }
    public static long Totient(long n)
    {
        long res = n;
        if ((n & 1) == 0)
        {
            res >>= 1;
            do { n >>= 1; } while ((n & 1) == 0);
        }
        for (long i = 3; i * i <= n; i += 2)
        {
            long rem, div = DivRem(n, i, out rem);
            if (rem == 0)
            {
                res = (res / i) * (i - 1);
                do { n = div; div = DivRem(n, i, out rem); } while (rem == 0);
            }
        }
        if (n != 1) res = (res / n) * (n - 1);
        return res;
    }
}
