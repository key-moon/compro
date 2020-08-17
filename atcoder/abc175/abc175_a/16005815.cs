// detail: https://atcoder.jp/contests/abc175/submissions/16005815
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
        int count = 0;
        int res = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'R') count++;
            else count = 0;
            res = Max(count, res);
        }
        Console.WriteLine(res);
    }
}
