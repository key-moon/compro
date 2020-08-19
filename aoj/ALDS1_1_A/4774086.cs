// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_1_A/judge/4774086/C#
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(string.Join(" ", a));
        for (int i = 1; i < n; i++)
        {
            var v = a[i];
            int j;
            for (j = i - 1; 0 <= j && v < a[j]; j--)
            {
                a[j + 1] = a[j];
            }
            a[j + 1] = v;
            Console.WriteLine(string.Join(" ", a));
        }
    }
}
