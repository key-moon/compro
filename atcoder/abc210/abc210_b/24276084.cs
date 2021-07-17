// detail: https://atcoder.jp/contests/abc210/submissions/24276084
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


        Console.WriteLine(Console.ReadLine().Select((x, y) => (x, y)).First(x => x.x == '1').y % 2 == 0 ? "Takahashi" : "Aoki");

    }
}