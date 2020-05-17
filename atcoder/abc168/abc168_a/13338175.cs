// detail: https://atcoder.jp/contests/abc168/submissions/13338175
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
        string s = (Console.ReadLine());
        Console.WriteLine(s.Last() == '3' ? "bon" : new[] { '0', '1', '6', '8' }.Contains(s.Last()) ? "pon" : "hon");
    }
}