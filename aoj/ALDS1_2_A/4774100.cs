// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_2_A/judge/4774100/C#
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
        int count = 0;

        var flag = true;
        while (flag)
        {
            flag = false;
            for (int i = n - 1; i >= 1; i--)
            {
                if (a[i] < a[i - 1])
                {
                    var tmp = a[i];
                    a[i] = a[i - 1];
                    a[i - 1] = tmp;
                    flag = true;
                    count++;
                }
            }
        }


        Console.WriteLine(string.Join(" ", a));
        Console.WriteLine(count);
    }
}
