// detail: https://atcoder.jp/contests/tkppc6-1/submissions/25259516
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
        Console.WriteLine(n <= 2014 || n == 2017 ? -1 : n <= 2016 ? n - 2014 : n - 2015);
    }
}