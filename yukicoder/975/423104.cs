// detail: https://yukicoder.me/submissions/423104
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
        var xnm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var x = xnm[0];
        var n = xnm[1];
        var m = xnm[2];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var existsInA = a.Contains(x);
        var existsInB = b.Contains(x);

        Console.WriteLine(existsInA && existsInB ? "MrMaxValu" : existsInA ? "MrMax" : existsInB ? "MaxValu" : "-1");
    }
}