// detail: https://atcoder.jp/contests/abc167/submissions/21551689
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
        var a = Console.ReadLine();
        var b = Console.ReadLine();

        Console.WriteLine(b.StartsWith(a) && a.Length + 1 == b.Length ? "Yes" : "No");
    }
}
