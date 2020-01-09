// detail: https://codeforces.com/contest/1282/submission/68432348
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
        var abcr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abcr[0];
        var b = abcr[1];
        if (b < a) { var tmp = a; a = b; b = tmp; }
        var len = b - a;
        var c = abcr[2];
        var r = abcr[3];
        var cb = c - r;
        var ce = c + r;
        Console.WriteLine(Min(Max(cb - a, 0), len) + Min(Max(b - ce, 0), len));
    }
}
