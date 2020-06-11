// detail: https://atcoder.jp/contests/abc079/submissions/14183145
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
        long a = 2;
        long b = 1;
        for (int i = 2; i <= n; i++)
        {
            var tmp = b;
            b = a + b;
            a = tmp;
        }
        Console.WriteLine(b);
    }
}