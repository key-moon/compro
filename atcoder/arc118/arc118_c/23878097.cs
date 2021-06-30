// detail: https://atcoder.jp/contests/arc118/submissions/23878097
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
        Console.WriteLine(string.Join(" ", Valid().Skip(1).Take(n)));
    }
    static IEnumerable<int> Valid()
    {
        int a = 1;
        while (true)
        {
            var score = 0;
            if (a % 2 == 0) score++;
            if (a % 3 == 0) score++;
            if (a % 5 == 0) score++;
            if (2 <= score) yield return a;
            a++;
        }
    }
}