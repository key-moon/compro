// detail: https://atcoder.jp/contests/abc169/submissions/13790066
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
        var ab = Console.ReadLine().Split();
        Console.WriteLine(long.Parse(ab[0]) * long.Parse(ab[1].Replace(".", "")) / 100);
    }
}
