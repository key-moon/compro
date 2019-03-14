// detail: https://yukicoder.me/submissions/322504
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).ToList();
        var gcd = a.Aggregate(0L, GCD);
        Console.WriteLine(string.Join(":", a.Select(x => x / gcd)));
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (a > b)
            {
                if (b == 0) return a;
                a %= b;
            }
            else
            {
                if (a == 0) return b;
                b %= a;
            }
        }
    }
}
