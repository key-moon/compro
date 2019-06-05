// detail: https://codeforces.com/contest/1175/submission/55146836
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var accumlate = new long[n];
        accumlate[n - 1] = a[n - 1];
        for (int i = n - 2; i >= 0; i--) accumlate[i] = accumlate[i + 1] + a[i];
        Console.WriteLine(accumlate[0] + accumlate.Skip(1).OrderByDescending(x => x).Take(k - 1).Sum());
    }
}
