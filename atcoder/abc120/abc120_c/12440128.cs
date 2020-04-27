// detail: https://atcoder.jp/contests/abc120/submissions/12440128
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
        var s = Console.ReadLine();
        Console.WriteLine(s.Length - Abs(s.Count(x => x == '0') - s.Count(x => x == '1')));
    }
}