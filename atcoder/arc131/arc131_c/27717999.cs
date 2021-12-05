// detail: https://atcoder.jp/contests/arc131/submissions/27717999
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
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var xor = a.Aggregate(0, (x, y) => x ^ y);
        if (a.Contains(xor))
        {
            Console.WriteLine("Win");
            return;
        }
        Console.WriteLine(n % 2 == 0 ? "Lose" : "Win");
    }
}