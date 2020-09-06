// detail: https://codeforces.com/contest/1404/submission/92030004
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        char[] s = Console.ReadLine().ToArray();
        char[] pattern = Enumerable.Repeat('?', k).ToArray();
        for (int i = 0; i < n; i++)
        {
            var type = i % k;
            if (s[i] == '?') continue;
            if (pattern[type] == '?')
            {
                pattern[type] = s[i];
                continue;
            }
            if (pattern[type] != s[i])
            {
                Console.WriteLine("No");
                return;
            }
        }
        int count0 = 0;
        int count1 = 0;
        for (int i = 0; i < pattern.Length; i++)
        {
            if (pattern[i] == '0') count0++;
            if (pattern[i] == '1') count1++;
        }
        Console.WriteLine(count0 <= k / 2 && count1 <= k / 2 ? "Yes" : "No");
    }
}
