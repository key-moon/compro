// detail: https://atcoder.jp/contests/abc117/submissions/22930381
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
        var tx = Console.ReadLine().Split().Select(double.Parse).ToArray();
        Console.WriteLine(tx[0] / tx[1]);
    }
}