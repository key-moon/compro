// detail: https://atcoder.jp/contests/abc216/submissions/25403704
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
        long n = long.Parse(Console.ReadLine());
        string res = "";
        while (n != 0)
        {
            if ((n & 1) == 1)
            {
                n -= 1;
                res = 'A' + res;
            }
            n /= 2;
            res = 'B' + res;
        }
        Console.WriteLine(res);
    }
}
