// detail: https://codeforces.com/contest/1202/submission/58446315
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        string[] res = new string[q];
        for (int i = 0; i < q; i++)
            res[i] = Solve(int.Parse(Console.ReadLine()));
        Console.WriteLine(string.Join("\n", res));
    }

    static string Solve(int n)
    {
        List<char> res = new List<char>();
        for (int i = 45000; i >= 2; i--)
        {
            var a = i * (i - 1) / 2;
            res.AddRange(Enumerable.Repeat('7', n / a));
            n %= a;
            if (res.Count != 0) res.Add('3');
        }
        res.Add('3');
        res.Add('1');

        return string.Join("", res.Reverse<char>());
    }
}

