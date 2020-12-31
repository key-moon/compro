// detail: https://yukicoder.me/submissions/598621
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
        var avg = a.Average();

        Console.WriteLine(string.Join("\n", a.Select(x => Floor(50 - (avg - x) / 2))));
    }
}