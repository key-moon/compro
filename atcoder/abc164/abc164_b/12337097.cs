// detail: https://atcoder.jp/contests/abc164/submissions/12337097
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
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abcd[0];
        var b = abcd[1];
        var c = abcd[2];
        var d = abcd[3];
        while (true)
        {
            c -= b;
            if (c <= 0)
            {
                Console.WriteLine("Yes");
                return;
            }
            a -= d;
            if (a <= 0)
            {
                Console.WriteLine("No");
                return;
            }
        }
    }
}