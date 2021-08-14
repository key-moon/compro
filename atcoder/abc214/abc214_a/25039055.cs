// detail: https://atcoder.jp/contests/abc214/submissions/25039055
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
        int res = 0;
        if (n <= 125) res = 4;
        else if (n <= 211) res = 6;
        else res = 8;
        Console.WriteLine(res);
    }
}