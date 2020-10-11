// detail: https://atcoder.jp/contests/arc105/submissions/17341112
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
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var (a, b, c, d) = (abcd[0], abcd[1], abcd[2], abcd[3]);

        if (a == b + c + d || b == a + c + d || c == a + b + d || d == a + b + c ||
            a + b == c + d || a + c == b + d || a + d == b + c) Console.WriteLine("Yes");
        else Console.WriteLine("No");
    }
}