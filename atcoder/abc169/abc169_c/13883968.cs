// detail: https://atcoder.jp/contests/abc169/submissions/13883968
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
        var ab = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
        Console.WriteLine(Floor((ab[0] * ab[1])));
    }
}
