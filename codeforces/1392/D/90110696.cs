// detail: https://codeforces.com/contest/1392/submission/90110696
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
        var s = Console.ReadLine();
        var res = Solve(s);
        s = s.Substring(1) + s[0];
        res = Min(res, Solve(s));
        s = s.Substring(1) + s[0];
        res = Min(res, Solve(s));
        s = s.Substring(1) + s[0];
        res = Min(res, Solve(s));
        Console.WriteLine(res);
    }
    static int[] DP = new int[200001];
    static int Solve(string s)
    {
        DP[0] = 0;
        var cands = new string[]{
            "RL",
            "RRL",
            "RLL",
            "RRLL"
        };
        for (int i = 1; i <= s.Length; i++)
        {
            DP[i] = int.MaxValue / 2;
            foreach (var cand in cands)
            {
                if (cand.Length <= i)
                {
                    int diff = 0;
                    for (int j = 0; j < cand.Length; j++)
                    {
                        if (cand[j] != s[i - cand.Length + j]) diff++;
                    }
                    DP[i] = Min(DP[i - cand.Length] + diff, DP[i]);
                }
            }
        }
        return DP[s.Length];
    }
}
