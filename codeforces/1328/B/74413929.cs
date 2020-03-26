// detail: https://codeforces.com/contest/1328/submission/74413929
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
        {
            Solve();
        }
    }
    static void Solve() 
    {
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var valid = 1L;
        var invalid = n;
        while (invalid - valid > 1)
        {
            var mid = (invalid + valid) / 2;
            if (mid * (mid - 1) / 2 < k) valid = mid;
            else invalid = mid;
        }
        char[] res = Enumerable.Repeat('a', (int)n).ToArray();
        res[n - (valid + 1)] = 'b';
        res[n - (k - valid * (valid - 1) / 2)] = 'b';
        Console.WriteLine(string.Join("", res));
    }
}
