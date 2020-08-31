// detail: https://atcoder.jp/contests/donuts-2015/submissions/16426164
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
        var rd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = rd[0];
        var d = rd[1];
        Console.WriteLine(r * r * PI * d * 2 * PI);
    }
}