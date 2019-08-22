// detail: https://codeforces.com/contest/1207/submission/59276643
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;

static class P
{
    static void Main()
    {
        var t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var bpf = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var hc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Solve(bpf[0], bpf[1], bpf[2], hc[0], hc[1]));
        }
    }

    static int Solve(int b, int p, int f, int h, int c)
    {
        return Max(Min(b / 2, p) * h + Min(Max(b / 2 - p, 0), f) * c, Min(b / 2, f) * c + Min(Max(0, b / 2 - f), p) * h);
    }
}
