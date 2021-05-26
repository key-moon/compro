// detail: https://atcoder.jp/contests/abc075/submissions/22930285
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
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Aggregate((x, y) => x ^ y));
    }
}