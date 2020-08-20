// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_9_A/judge/4775015/C#
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
        var a = ("0 " + Console.ReadLine()).Split().Select(int.Parse).ToArray();
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"node {i}: key = {a[i]}, ");
            if (i != 1) Console.Write($"parent key = {a[i / 2]}, ");
            if (i * 2 <= n) Console.Write($"left key = {a[i * 2]}, ");
            if (i * 2 + 1 <= n) Console.Write($"right key = {a[i * 2 + 1]}, ");
            Console.WriteLine();
        }
    }
}

