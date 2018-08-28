// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0361/judge/3111862/C#
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(xy[0] + xy[1] - gcd(xy[0], xy[1]) + 1);
    }

    static int gcd(int a, int b)
    {
        if (a < b) return gcd(b, a);
        while (b != 0)
        {
            var r = a % b;
            a = b;
            b = r;
        }
        return a;
    }
}
