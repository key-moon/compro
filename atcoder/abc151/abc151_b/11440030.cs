// detail: https://atcoder.jp/contests/abc151/submissions/11440030
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
        var nkm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = nkm[1];
        var m = nkm[2];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = Max(0, m * nkm[0] - a.Sum());
        Console.WriteLine(res > k ? -1 : res);
    }
}
