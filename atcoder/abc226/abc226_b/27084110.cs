// detail: https://atcoder.jp/contests/abc226/submissions/27084110
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
        Console.WriteLine(Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).Distinct().Count());
    }
}