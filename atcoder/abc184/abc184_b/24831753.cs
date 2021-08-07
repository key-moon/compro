// detail: https://atcoder.jp/contests/abc184/submissions/24831753
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
        var nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int ptr = nx[1];
        var s = Console.ReadLine();
        foreach (var c in s)
        {
            if (c == 'o') ptr++;
            else ptr--;
            if (ptr < 0) ptr = 0;
        }
        Console.WriteLine(ptr);
    }
}