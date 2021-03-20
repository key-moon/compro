// detail: https://atcoder.jp/contests/joi2011yo/submissions/21050359
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
        string s = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        var res = Enumerable.Repeat(0, n).Count(_ =>
        {
            var t = Console.ReadLine();
            t = t + t.Substring(0, s.Length - 1);
            return t.Contains(s);
        });
        Console.WriteLine(res);
    }
}