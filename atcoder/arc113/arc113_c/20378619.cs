// detail: https://atcoder.jp/contests/arc113/submissions/20378619
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
        int[] charcnt = new int[26];
        var prev = '#';
        long res = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            var c = s[i];
            var ind = c - 'a';
            charcnt[ind]++;
            if (prev == c)
            {
                for (int j = 0; j < charcnt.Length; j++)
                {
                    if (ind != j) res += charcnt[j];
                    charcnt[j] = 0;
                }
                charcnt[ind] = s.Length - i;
            }
            prev = c;
        }
        Console.WriteLine(res);
    }
}