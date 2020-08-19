// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_2_D/judge/4774386/C#
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
        List<int> gs = new List<int>() { 1 };
        while (gs.Last() * 3 + 1 < n)
        {
            gs.Add(gs.Last() * 3 + 1);
        }
        gs.Reverse();

        Console.WriteLine(gs.Count);
        Console.WriteLine(string.Join(" ", gs));

        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();

        int cnt = 0;
        foreach (var g in gs)
        {
            for (int i = g; i < n; i++)
            {
                var v = a[i];
                int j;
                for (j = i - g; j >= 0 && a[j] > v; j -= g)
                {
                    a[j + g] = a[j];
                    cnt++;
                }
                a[j + g] = v;
            }
        }
        Console.WriteLine(cnt);

        Console.WriteLine(string.Join("\n", a));
    }
}
