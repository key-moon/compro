// detail: https://yukicoder.me/submissions/612258
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        List<long> factors = new List<long>();
        for (long i = 1; (i * i) <= n; i++)
        {
            if (n % i != 0) continue;
            factors.Add(i);
            factors.Add(n / i);
        }
        Console.WriteLine(factors.Where(x => 3 <= x).Min());
    }
}
