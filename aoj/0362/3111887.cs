// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0362/judge/3111887/C#
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
        int n = int.Parse(Console.ReadLine());
        int[] a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine()) / 10).ToArray();

        int maxDist = 0;
        for (int i = 0; i < n; i++)
        {
            if (i > maxDist) goto no;
            maxDist = Max(maxDist, i + a[i]);
        }
        maxDist = n - 1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (i < maxDist) goto no;
            maxDist = Min(maxDist, i - a[i]);
        }
        Console.WriteLine("yes");
        return;
        no:;
        Console.WriteLine("no");
    }
}
