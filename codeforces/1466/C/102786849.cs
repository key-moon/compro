// detail: https://codeforces.com/contest/1466/submission/102786849
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
        var s = Console.ReadLine().Select(x => (int)x).ToArray();
        int special = 200;
        int res = 0;
        if (2 <= s.Length && s[0] == s[1])
        {
            res++;
            s[1] = ++special;
        }
        for (int i = 2; i < s.Length; i++)
        {
            if (s[i - 1] == s[i] || s[i - 2] == s[i])
            {
                res++;
                s[i] = ++special;
            }
        }
        Console.WriteLine(res);
    }
}
