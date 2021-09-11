// detail: https://atcoder.jp/contests/abc218/submissions/25742897
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(string.Join("", a.Select(x => (char)(x + 'a' - 1))));
    }
}