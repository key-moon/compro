// detail: https://atcoder.jp/contests/abc015/submissions/16279208
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
        var a = Console.ReadLine();
        var b = Console.ReadLine();

        Console.WriteLine(a.Length < b.Length ? b : a);
    }
}
