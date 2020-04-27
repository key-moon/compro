// detail: https://atcoder.jp/contests/arc008/submissions/12440100
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
        Console.WriteLine(n / 10 * 100 + (n % 10 <= 6 ? (n % 10) * 15 : 100));
    }
}