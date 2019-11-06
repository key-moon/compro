// detail: https://codeforces.com/contest/1242/submission/64404561
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
 
public static class P
{
    public static void Main()
    {
        var n = long.Parse(Console.ReadLine());
        var factors = PrimeFactors(n).Distinct().ToArray();
        if (factors.Length == 1)
        {
            Console.WriteLine(factors[0]);
            return;
        }
        Console.WriteLine(1);
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