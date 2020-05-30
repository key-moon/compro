// detail: https://atcoder.jp/contests/nomura2020/submissions/13715101
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
        var hmhmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var min = (int)(new DateTime(2000, 1, 1, hmhmk[2], hmhmk[3], 0) - new DateTime(2000, 1, 1, hmhmk[0], hmhmk[1], 0)).TotalMinutes;
        Console.WriteLine(min - hmhmk[4]);
    }
}
