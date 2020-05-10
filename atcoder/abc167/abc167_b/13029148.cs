// detail: https://atcoder.jp/contests/abc167/submissions/13029148
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
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = nmk[0];
        var b = nmk[1];
        var c = nmk[2];
        var k = nmk[3];
        var res = 0;
        var take = Min(a, k);
        k -= take;
        res += take;
        take = Min(b, k);
        k -= take;
        take = Min(c, k);
        res -= take;
        Console.WriteLine(res);
    }
}
