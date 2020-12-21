// detail: https://atcoder.jp/contests/panasonic2020/submissions/18920037
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
        var abc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = abc[0];
        var b = abc[1];
        var c = abc[2];
        //a + b + 2 * Sqrt(a * b) < c
        //Sqrt(a * b) < (c - a - b) / 2
        
        if (0 <= c - a - b && a * b * 4 < (c - a - b) * (c - a - b)) Console.WriteLine("Yes");
        else Console.WriteLine("No");
    }
}