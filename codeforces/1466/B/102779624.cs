// detail: https://codeforces.com/contest/1466/submission/102779624
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

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int last = a[0];
        int res = 1;
        bool hasDouble = false;
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] == last)
            {
                hasDouble = true;
                continue;
            }
            if (last + 1 < a[i])
            {
                if (hasDouble) res++;
                hasDouble = false;
            }
            res++;
            last = a[i];
        }
        if (hasDouble) res++;
        Console.WriteLine(res);
    }
}
