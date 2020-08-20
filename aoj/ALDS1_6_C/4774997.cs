// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_6_C/judge/4774997/C#
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
        var a = Enumerable.Repeat(0, n).Select(_ =>
        {
            var input = Console.ReadLine().Split();
            return new Tuple<char, int>(input[0][0], int.Parse(input[1]));
        }).ToArray();
        var sortedA = a.OrderBy(x => x.Item2).ToArray();
        QuickSort(a, 0, a.Length - 1);
        Console.WriteLine(sortedA.SequenceEqual(a) ? "Stable" : "Not stable");

        Console.WriteLine(string.Join("\n", a.Select(x => $"{x.Item1} {x.Item2}")));
    }

    static void QuickSort(Tuple<char, int>[] a, int p, int r)
    {
        if (p >= r) return;
        var q = Partation(a, p, r);
        QuickSort(a, p, q - 1);
        QuickSort(a, q + 1, r);
    }

    static int Partation(Tuple<char, int>[] a, int p, int r)
    {
        var x = a[r];
        int i = p - 1;
        for (int j = p; j < r; j++)
        {
            if (a[j].Item2 <= x.Item2)
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

