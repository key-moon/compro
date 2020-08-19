// detail: https://atcoder.jp/contests/abc136/submissions/16040867
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
        string s = Console.ReadLine();
        int[] res = new int[s.Length];
        int streak = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != 'R')
            {
                res[i] += streak / 2;
                res[i - 1] += streak - streak / 2;
                streak = 0;
            }
            else streak++;
        }

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] != 'L')
            {
                res[i] += streak / 2;
                res[i + 1] += streak - streak / 2;
                streak = 0;
            }
            else streak++;
        }


        Console.WriteLine(string.Join(" ", res));
    }
}