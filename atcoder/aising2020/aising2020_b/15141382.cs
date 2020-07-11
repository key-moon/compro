// detail: https://atcoder.jp/contests/aising2020/submissions/15141382
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
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Where((x, y) => x % 2 == 1 && y % 2 == 0).Count());
    }
}
