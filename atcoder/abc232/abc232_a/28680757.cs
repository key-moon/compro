// detail: https://atcoder.jp/contests/abc232/submissions/28680757
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
        var ab = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
        Console.WriteLine(ab[0] * ab[1]);
    }
}