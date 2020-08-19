// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_1_C/judge/4774090/C#
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
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            var a = int.Parse(Console.ReadLine());
            for (int j = 2; j * j <= a; j++)
                if (a % j == 0) goto end;
            res++;
            end:;
        }
        Console.WriteLine(res);
    }
}
