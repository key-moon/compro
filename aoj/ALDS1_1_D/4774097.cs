// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_1_D/judge/4774097/C#
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
        int res = int.MinValue;
        int curMin = int.Parse(Console.ReadLine());
        for (int i = 1; i < n; i++)
        {
            var a = int.Parse(Console.ReadLine());
            res = Max(res, a - curMin);
            curMin = Min(curMin, a);
        }
        Console.WriteLine(res);
    }
}
