// detail: https://atcoder.jp/contests/abc165/submissions/12606219
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
        var x = long.Parse(Console.ReadLine());
        int year = 0;
        long cur = 100;
        while (cur < x)
        {
            cur += cur / 100;
            year++;
        }
        Console.WriteLine(year);
    }
}