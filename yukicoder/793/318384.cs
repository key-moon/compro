// detail: https://yukicoder.me/submissions/318384
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
using static System.Math;

class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        //E_i=4*10^n - 1 / 3
        Console.WriteLine(((4 * Power(10, n) + 1000000007 - 1) * Power(3, 1000000007 - 2)) % 1000000007);
    }

    static long Power(long n, long m)
    {
        const int mod = 1000000007;
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res = (res * pow) % mod;
            pow = (pow * pow) % mod;
            m >>= 1;
        }
        return res;
    }
}
