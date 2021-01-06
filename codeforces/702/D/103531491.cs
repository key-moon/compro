// detail: https://codeforces.com/contest/702/submission/103531491
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
        var dkabt = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
        var d = dkabt[0];
        var k = dkabt[1];
        var a = dkabt[2];
        var b = dkabt[3];
        var t = dkabt[4];
        if (d <= k)
        {
            Console.WriteLine(d * a);
            return;
        }
        BigInteger offset = k * a;
        d -= k;
        BigInteger res = long.MaxValue;
        void Update(BigInteger val) { if (res > val) res = val; }
        var sections = d / k;
        var remain = d % k;
        Update(sections * (a * k + t) + remain * b);
        Update(sections * (a * k + t) + t + remain * a);
        Update(b * d);
        Console.WriteLine(res + offset);
    }
}