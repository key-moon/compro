// detail: https://atcoder.jp/contests/abc160/submissions/11275414
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
        var kn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = kn[0];
        var n = kn[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res1 = a.Skip(1).Zip(a, (x, y) => x - y).Max();
        var res2 = (a.First() + k) - a.Last();
        Console.WriteLine(k - Max(res1, res2));
    }
}
