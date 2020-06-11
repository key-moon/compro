// detail: https://atcoder.jp/contests/abc079/submissions/14183135
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
        Console.WriteLine(s.Substring(0, 3).Distinct().Count() == 1 || s.Substring(1, 3).Distinct().Count() == 1 ? "Yes" : "No");
    }
}

