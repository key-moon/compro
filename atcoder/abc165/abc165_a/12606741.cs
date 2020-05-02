// detail: https://atcoder.jp/contests/abc165/submissions/12606741
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
        int k = int.Parse(Console.ReadLine());
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        for (int i = a; i <= b; i++)
        {
            if (i % k == 0)
            {
                Console.WriteLine("OK");
                return;
            }
        }
        Console.WriteLine("NG");
    }
}