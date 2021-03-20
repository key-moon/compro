// detail: https://atcoder.jp/contests/abc196/submissions/21061616
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var cd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int max = int.MinValue;
        for (int i = ab[0]; i <= ab[1]; i++)
        {
            for (int j = cd[0]; j <= cd[1]; j++)
            {
                max = Max(max, i - j);
            }
        }
        Console.WriteLine(max);
    }
}