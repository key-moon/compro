// detail: https://atcoder.jp/contests/cf17-final/submissions/22930138
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
        var s = Console.ReadLine();

        Console.WriteLine(Regex.IsMatch(s, @"^A?KIHA?BA?RA?$") ? "YES" : "NO");
    }
}