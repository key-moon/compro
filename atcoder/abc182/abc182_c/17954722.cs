// detail: https://atcoder.jp/contests/abc182/submissions/17954722
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
        int res = int.MaxValue;
        for (int i = 1; i < (1 << s.Length); i++)
        {
            string t = "";
            for (int j = 0; j < s.Length; j++)
            {
                if ((i >> j & 1) != 0) t += s[j];
            }
            if (long.Parse(t) % 3 == 0)
            {
                res = Min(res, s.Length - t.Length);
            }
        }
        if (res == int.MaxValue) res = -1;
        Console.WriteLine(res);
    }
}