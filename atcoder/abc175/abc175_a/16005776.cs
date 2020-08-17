// detail: https://atcoder.jp/contests/abc175/submissions/16005776
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
        if (s == "RRR") Console.WriteLine(3);
        else if (s.StartsWith("RR") || s.EndsWith("RR")) Console.WriteLine(2);
        else if (s.Contains("R")) Console.WriteLine(1);
        else Console.WriteLine(0);
    }
}