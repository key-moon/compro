// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0358/judge/3111825/C#
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] mfb = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int m = Max(0, mfb[2] - mfb[0]);
        Console.WriteLine(m > mfb[1] ? "NA" : m.ToString());
    }
}

