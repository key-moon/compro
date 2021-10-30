// detail: https://atcoder.jp/contests/abc225/submissions/26893213
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
        Console.WriteLine(s.Distinct().Count() switch { 3 => 6, 2 => 3, 1 => 1 });
    }
}