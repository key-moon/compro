// detail: https://atcoder.jp/contests/abc158/submissions/10591914
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
        var nab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nab[0];
        var a = nab[1];
        var b = nab[2];
        Console.WriteLine(n / (a + b) * a + Min(n % (a + b), a));
    }
}