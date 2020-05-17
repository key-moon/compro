// detail: https://atcoder.jp/contests/abc167/submissions/13289457
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
        string s = Console.ReadLine();
        string t = Console.ReadLine();

        Console.WriteLine(s.Length == t.Length - 1 && t.StartsWith(s) ? "Yes" : "No");
    }
}
