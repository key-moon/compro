// detail: https://yukicoder.me/submissions/428238
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        if (GCD(a, b) != 1)
        {
            Console.WriteLine(-1);
            return;
        }
        bool[] memo = new bool[a * b * 2 + 1];
        for (int i = 0; i <= b; i++)
            for (int j = 0; j <= a; j++)
                memo[i * a + j * b] |= true;
        Console.WriteLine(memo.Take(a * b + 1).Count(x => !x));
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
