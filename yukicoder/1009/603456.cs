// detail: https://yukicoder.me/submissions/603456
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        double Integral(double x) => x * (6 * a * b - (3 * (a + b) * x) + 2 * x * x) / 6;
        Console.WriteLine(Abs(Integral(b) - Integral(a)));
    }
}