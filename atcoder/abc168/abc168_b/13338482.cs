// detail: https://atcoder.jp/contests/abc168/submissions/13338482
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
        var s = Console.ReadLine();
        if (s.Length > n) s = s[0..n] + "...";
        Console.WriteLine(s);
    }
}