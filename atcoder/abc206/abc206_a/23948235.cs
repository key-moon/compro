// detail: https://atcoder.jp/contests/abc206/submissions/23948235
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
        var n = int.Parse(Console.ReadLine());
        var price = n + n * 8 / 100;
        Console.WriteLine(price < 206 ? "Yay!" : price == 206 ? "so-so" : ":(");
    }
}