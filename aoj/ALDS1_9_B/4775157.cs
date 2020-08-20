// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_9_B/judge/4775157/C#
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
        for (int i = n / 2; i >= 1; i--)
            Heapfy(a, i, n);
        Console.WriteLine(" " + string.Join(" ", a.Skip(1)));
    }
    static void Heapfy(int[] a, int i, int n)
    {
        var l = i * 2;
        var r = i * 2 + 1;

        var largest = l <= n && a[i] < a[l] ? l : i;
        if (r <= n && a[largest] < a[r]) largest = r;

        if (largest != i)
        {
            var tmp = a[i];
            a[i] = a[largest];
            a[largest] = tmp;
            Heapfy(a, largest, n);
        }
    }
}

