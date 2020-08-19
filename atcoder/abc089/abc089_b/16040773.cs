// detail: https://atcoder.jp/contests/abc089/submissions/16040773
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
        int n = int.Parse(Console.ReadLine());
        var res = Console.ReadLine().Split().Distinct().Count();
        Console.WriteLine(res == 3 ? "Three" : "Four");
    }
}
