// detail: https://codeforces.com/contest/665/submission/99549119
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
        var s = (Console.ReadLine() + '$').ToArray();
        char last = '#';
        int start = 0;
        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (last != s[i])
            {
                var c = (char)Enumerable.Range('a', 26).First(x => x != last && x != s[i]);
                for (int j = start + 1; j < i; j += 2) s[j] = c;
                start = i;
            }
            last = s[i];
        }
        Console.WriteLine(string.Join("", s.Take(s.Length - 1)));
    }
}