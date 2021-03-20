// detail: https://atcoder.jp/contests/joi2011yo/submissions/21050358
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
        var sec = Enumerable.Repeat(0, 4).Select(_ => int.Parse(Console.ReadLine())).Sum();
        Console.WriteLine(sec / 60);
        Console.WriteLine(sec % 60);
    }
}