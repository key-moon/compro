// detail: https://atcoder.jp/contests/arc104/submissions/17166908
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
        var ns = Console.ReadLine().Split();
        var n = int.Parse(ns[0]);
        var s = ns[1];
        int[] atcount = new int[n + 1];
        int[] cgcount = new int[n + 1];

        for (int i = 0; i < n; i++)
        {
            atcount[i + 1] = atcount[i];
            cgcount[i + 1] = cgcount[i];
            switch (s[i])
            {
                case 'A':
                    atcount[i + 1]++;
                    break;
                case 'T':
                    atcount[i + 1]--;
                    break;
                case 'C':
                    cgcount[i + 1]++;
                    break;
                case 'G':
                    cgcount[i + 1]--;
                    break;
                default:
                    break;
            }
        }
        int res = 0;
        for (int i = 0; i <= n; i++)
        {
            for (int j = i + 1; j <= n; j++)
            {
                if (atcount[j] == atcount[i] && cgcount[j] == cgcount[i])
                {
                    //Console.WriteLine($"{i} {j}");
                    res++;
                }
            }
        }
        Console.WriteLine(res);

    }
}
