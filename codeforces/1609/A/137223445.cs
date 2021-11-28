// detail: https://codeforces.com/contest/1609/submission/137223445
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
            int cnt = 0;
            for (int j = 0; j < a.Length; j++)
            {
                while (a[j] % 2 == 0)
                {
                    cnt++;
                    a[j] /= 2;
                }
            }
            a = a.OrderByDescending(x => x).ToArray();
            for (int j = 0; j < cnt; j++) a[0] *= 2;
            Console.WriteLine(a.Sum());
        }
    }
}