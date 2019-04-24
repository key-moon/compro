// detail: https://codeforces.com/contest/1152/submission/53253061
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using Debug = System.Diagnostics.Debug;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;

static class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        var a = ab[0];
        var b = ab[1];
        if (a == b)
        {
            Console.WriteLine(0);
            return;
        }
        long smallest = long.MaxValue;
        long smallestK = -1;
        var diff = Abs(b - a);
        foreach (var div in Divisor(diff))
        {
            var k = (div - a % div) % div;
            var lcm = (a + k) * (b + k) / div;
            if (lcm < smallest)
            {
                smallest = lcm;
                smallestK = k;
            }
        }
        Console.WriteLine(smallestK);
    }

    static long[] Divisor(long n)
    {
        List<long> res = new List<long>();
        long i = 1;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                res.Add(i);
                if (i * i != n) res.Add(n / i);
            }
            i++;
        }
        return res.OrderBy(x => x).ToArray();
    }
}