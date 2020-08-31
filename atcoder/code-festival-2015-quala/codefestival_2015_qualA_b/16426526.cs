// detail: https://atcoder.jp/contests/code-festival-2015-quala/submissions/16426526
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int s = 0;
        foreach (var item in a)
            s = s + item + s;
        Console.WriteLine(s);
    }
}