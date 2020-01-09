// detail: https://codeforces.com/contest/1282/submission/68432803
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
            Solve();
    }
    static void Solve()
    {
        var npk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = npk[0];
        var p = npk[1];
        var k = npk[2];
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        var accum = new long[n];
        accum[0] = a[0];
        for (int i = 1; i < k - 1; i++)
            accum[i] = accum[i - 1] + a[i];
        accum[k - 1] = a[k - 1];
        for (int i = k; i < n; i++)
            accum[i] = accum[i - k] + a[i];
        for (int i = a.Length - 1; i >= 0; i--)
            if (accum[i] <= p)
            {
                Console.WriteLine(i + 1);
                return;
            }
        Console.WriteLine(0);
        return;
    }
}
