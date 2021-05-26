// detail: https://atcoder.jp/contests/soundhound2018-summer-qual/submissions/22930229
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
        var w = int.Parse(Console.ReadLine());
        string res = "";
        for (int i = 0; i < s.Length; i += w) res += s[i];
        Console.WriteLine(res);
    }
}