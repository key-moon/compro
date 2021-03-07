// detail: https://atcoder.jp/contests/abc194/submissions/20755075
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        a += b;
        if (15 <= a && 8 <= b) Console.WriteLine(1);
        else if (10 <= a && 3 <= b) Console.WriteLine(2);
        else if (3 <= a) Console.WriteLine(3);
        else Console.WriteLine(4);
    }
}
