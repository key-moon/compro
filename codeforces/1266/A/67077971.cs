// detail: https://codeforces.com/contest/1266/submission/67077971
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
        string s = Console.ReadLine();
        if (s.Contains('0') && s.Sum(x => x - '0') % 3 == 0 && 2 <= s.Count(x => (x - '0') % 2 == 0))
        {
            Console.WriteLine("red");
        }
        else
        {
            Console.WriteLine("cyan");
        }
    }
}
