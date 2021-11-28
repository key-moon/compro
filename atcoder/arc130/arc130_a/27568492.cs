// detail: https://atcoder.jp/contests/arc130/submissions/27568492
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
        string s = Console.ReadLine();
        char prev = '^';
        long streak = 0;
        long res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (prev != s[i])
            {
                res += (streak - 1) * streak / 2;
                streak = 0;
            }
            prev = s[i];
            streak++;
        }
        res += (streak - 1) * streak / 2;
        Console.WriteLine(res);
    }
}