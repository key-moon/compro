// detail: https://atcoder.jp/contests/abc180/submissions/17454211
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
        var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(nab[0] - nab[1] + nab[2]);
    }
}