// detail: https://codeforces.com/contest/1400/submission/90908305
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            Console.WriteLine(string.Join("", Enumerable.Repeat(s[n - 1], n)));
        }
    }
}
