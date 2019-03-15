// detail: https://yukicoder.me/submissions/323306
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine().Trim());
        var a = Console.ReadLine().Trim().Split().Select(long.Parse).ToList();
        //var a = Enumerable.Range(0, n).ToList();
        if (a.Count != n) throw new Exception();
        long res = a[0];
        long mul = 1;
        for (int i = 1; i < a.Count; i++)
        {
            mul = ((mul * (n - i)) % 1000000007) * Power(i, 1000000007 - 2);
            mul %= 1000000007;
            //Console.WriteLine(mul);
            res += mul * a[i];
            res %= 1000000007;
        }
        Console.WriteLine(res);
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
