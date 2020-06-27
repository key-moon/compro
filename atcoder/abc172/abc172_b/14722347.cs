// detail: https://atcoder.jp/contests/abc172/submissions/14722347
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
        Console.WriteLine(Console.ReadLine().Zip(Console.ReadLine(), (x, y) => x == y ? 0 : 1).Sum());
    }
}
