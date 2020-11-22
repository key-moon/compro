// detail: https://atcoder.jp/contests/abc184/submissions/18323340
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
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray().Concat(Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        Console.WriteLine(abcd[0] * abcd[3] - abcd[1] * abcd[2]);
    }
}