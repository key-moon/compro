// detail: https://atcoder.jp/contests/abc209/submissions/24116011
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
        Console.WriteLine(Max(0, ab[1] - ab[0] + 1));
    }
}