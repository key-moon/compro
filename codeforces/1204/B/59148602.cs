// detail: https://codeforces.com/contest/1204/submission/59148602
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

static class P
{
    static void Main()
    {
        var nlr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nlr[0];
        var l = nlr[1];
        var r = nlr[2];
        //偶数か1で、
        var min = ((1L << l) - 1) + 1L * (n - l);
        var max = ((1L << r) - 1) + (1L << (r - 1)) * (n - r);
        Console.WriteLine($"{min} {max}");
    }
}