// detail: https://atcoder.jp/contests/agc048/submissions/17506428
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
            Solve();
        }
    }
    static void Solve()
    {
        var ac = "atcoder";
        string s = Console.ReadLine();
        if (ac.CompareTo(s) < 0)
        {
            Console.WriteLine(0);
            return;
        }
        int min = int.MaxValue;
        for (int i = 0; i < Min(ac.Length , s.Length); i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (ac[i] < s[j]) min = Min(min, j - i);
            }
            if (ac[i] > s[i]) break;
        }
        Console.WriteLine(min == int.MaxValue ? -1 : min);
    }
}
