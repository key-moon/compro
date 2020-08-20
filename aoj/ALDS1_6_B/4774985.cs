// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_6_B/judge/4774985/C#
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
        var q = Partation(a, 0, a.Length - 1);

        Console.WriteLine(string.Join(" ", a.Select((elem, ind) => ind == q ? $"[{elem}]" : elem.ToString())));
    }

    static int Partation(int[] a, int p, int r)
    {
        var x = a[r];
        int i = p - 1;
        for (int j = p; j < r; j++)
        {
            if (a[j] <= x)
            {
                i++;
                { var tmp = a[i]; a[i] = a[j]; a[j] = tmp; }
            }
        }
        i++;
        { var tmp = a[r]; a[r] = a[i]; a[i] = tmp; }
        return i;
    }
}

