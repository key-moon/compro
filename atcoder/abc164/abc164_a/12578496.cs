// detail: https://atcoder.jp/contests/abc164/submissions/12578496
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
        var sw = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(sw[0] <= sw[1] ? "unsafe" : "safe");
    }
}
