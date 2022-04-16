// detail: https://atcoder.jp/contests/abc248/submissions/31013887
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
        var abk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = abk[0];
        var b = abk[1];
        var k = abk[2];
        int cnt = 0;
        while (a < b)
        {
            a *= k;
            cnt++;
        }
        Console.WriteLine(cnt);
    }
}