// detail: https://atcoder.jp/contests/code-formula-2014-qualb/submissions/31132150
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
        var odd = s.Where((x, y) => y % 2 == s.Length % 2).Sum(x => x - '0');
        var even = s.Where((x, y) => y % 2 != s.Length % 2).Sum(x => x - '0');
        Console.WriteLine($"{odd} {even}");
    }
}