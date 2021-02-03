// detail: https://codeforces.com/contest/808/submission/106357117
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
        var s = Console.ReadLine();
        long next = s.First() - '0' + 1;
        for (int i = 1; i < s.Length; i++)
        {
            next *= 10;
        }
        Console.WriteLine(next - int.Parse(s));
    }
}
