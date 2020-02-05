// detail: https://yukicoder.me/submissions/426363
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

static class P
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long res = 0;
        for (long i = 1; i * i <= n; i++)
        {
            if (n % i != 0) continue;
            res += i;
            if (i * i != n) res += n / i;
        }
        Console.WriteLine(res);
    }
}