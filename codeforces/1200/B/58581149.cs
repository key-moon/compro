// detail: https://codeforces.com/contest/1200/submission/58581149
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
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var h = Console.ReadLine().Split().Select(int.Parse).ToArray();
            builder.AppendLine(Solve(nmk[0], nmk[1], nmk[2], h) ? "YES" : "NO");
        }
        Console.Write(builder.ToString());
    }

    static bool Solve(int n, long m, long k, int[] h)
    {
        for (int i = 0; i < h.Length - 1; i++)
        {
            var current = h[i];
            var next = h[i + 1];
            var limit = Max(0, next - k);
            m += current - limit;
            if (m < 0) return false;
        }
        return true;
    }
}
