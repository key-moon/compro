// detail: https://codeforces.com/contest/710/submission/104674832
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
        int ind = 0;
        if (s.Contains('a') || s.Contains('h')) ind++;
        if (s.Contains('1') || s.Contains('8')) ind++;
        if (ind == 0) Console.WriteLine(8);
        if (ind == 1) Console.WriteLine(5);
        if (ind == 2) Console.WriteLine(3);
    }
}