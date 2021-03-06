// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_2_B/judge/4774103/C#
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
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            var min = a.Skip(i).Min();
            if (a[i] != min)
            {
                var ind = i + a.Skip(i).TakeWhile(x => x != min).Count();
                var tmp = a[i];
                a[i] = a[ind];
                a[ind] = tmp;
                res++;
            }
        }
        Console.WriteLine(string.Join(" ", a));
        Console.WriteLine(res);
    }
}
