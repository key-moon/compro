// detail: https://atcoder.jp/contests/abc105/submissions/23878135
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
        long n = int.Parse(Console.ReadLine());
        long b = 1;
        string res = "";
        while (n != 0)
        {
            int digit = (n & Abs(b)) != 0 ? 1 : 0;
            res = digit + res;
            n -= digit * b;
            b *= -2;
        }
        if (res == "") res = "0";
        Console.WriteLine(res);
    }
}