// detail: https://codeforces.com/contest/1268/submission/67338110
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
        var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var sum = a.Sum();
        var minus = a.Select((elem, ind) => elem % 2 == 0 ? 0 : ind % 2 == 0 ? 1 : -1).Sum();
        Console.WriteLine((sum - Abs(minus)) / 2);
    }
}
