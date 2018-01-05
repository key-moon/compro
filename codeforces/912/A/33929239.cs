// detail: https://codeforces.com/contest/912/submission/33929239
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        long[] ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long[] xyz = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine(Math.Max(0,(xyz[0] * 2 + xyz[1]) - ab[0]) + Math.Max(0, (xyz[2] * 3 + xyz[1]) - ab[1]));

    }
}