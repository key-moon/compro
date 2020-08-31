// detail: https://atcoder.jp/contests/code-festival-2014-final/submissions/16426660
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
        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var a = s[i] - '0';
            if (i % 2 == 1) a = -a;
            res += a;
        }
        Console.WriteLine(res);
    }
}