// detail: https://codeforces.com/contest/846/submission/111320133
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
public static class P
{
    public static void Main()
    {
        Action abort = () => { Console.WriteLine("NO"); Environment.Exit(0); };
        int n = int.Parse(Console.ReadLine());
        var b = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var xks = Enumerable.Repeat(0, n - 1).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        BigInteger[] amounts = b.Zip(a, (x, y) => (BigInteger)(x - y)).ToArray();
        for (int i = n - 1; i >= 1; i--)
        {
            var to = xks[i - 1][0] - 1;
            var ratio = xks[i - 1][1];
            if (amounts[i] < 0)
            {
                if (amounts[i] < long.MinValue) abort();
                amounts[to] += amounts[i] * ratio;
            }
            else
            {
                amounts[to] += amounts[i];
            }
        }
        if (amounts[0] < 0) abort();
        Console.WriteLine("YES");
    }
}