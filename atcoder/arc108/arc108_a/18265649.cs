// detail: https://atcoder.jp/contests/arc108/submissions/18265649
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
        var sp = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var s = sp[0];
        var p = sp[1];
        for (long i = 1; i * i <= p; i++)
        {
            var j = p / i;
            if (i + j == s)
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");
    }
}