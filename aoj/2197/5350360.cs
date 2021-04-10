// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2197/judge/5350360/C#
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
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            int res = 0;
            if (n == 0) return;
            for (int i = 1; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j >= 0; j--)
                {
                    sum += j;
                    if (sum == n)
                    {
                        res++;
                        break;
                    }
                }
            }
            Console.WriteLine(res);
        }
    }
}

