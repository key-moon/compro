// detail: https://codeforces.com/contest/1282/submission/68433694
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
            Solve();
    }
    static void Solve()
    {
        var nTab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nTab[0];
        var T = nTab[1];
        long a = nTab[2];
        long b = nTab[3];
        bool[] isHard = Console.ReadLine().Split().Select(x => x == "1").ToArray();
        var t = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var problems = isHard.Zip(t, (x, y) => new Problem() { IsHard = x, RequiredAt = y }).OrderBy(x => x.RequiredAt).ToArray();
        long res = 0;
        long time = 0;
        int remainEasy = problems.Count(x => !x.IsHard);
        for (int i = 0; i < problems.Length; i++)
        {
            if (time < problems[i].RequiredAt) 
                res = Max(res, i + Min((problems[i].RequiredAt - 1 - time) / a, remainEasy));
            time += problems[i].IsHard ? b : a;
            remainEasy -= problems[i].IsHard ? 0 : 1;
        }
        if (time <= T) res = n;
        Console.WriteLine(res);
    }
}

struct Problem
{
    public bool IsHard;
    public long RequiredAt;
}
