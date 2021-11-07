// detail: https://atcoder.jp/contests/abc226/submissions/27085163
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
        var input = Console.ReadLine().Split('.').Select(int.Parse).ToArray();
        Console.WriteLine(input[0] + (input[1] < 500 ? 0 : 1));
    }
}