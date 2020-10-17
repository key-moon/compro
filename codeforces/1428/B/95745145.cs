// detail: https://codeforces.com/contest/1428/submission/95745145
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
        for (int i = 0; i < n; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        s = s + s;
        bool all = s.All(x => x != '<') || s.All(x => x != '>');
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '-' || s[i + n - 1] == '-' || all) res++;
        }
        Console.WriteLine(res);
    }
}