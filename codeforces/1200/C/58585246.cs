// detail: https://codeforces.com/contest/1200/submission/58585246
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
        var nmq = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var gcd = GCD(nmq[0], nmq[1]);
        var sectionLength = new long[] { nmq[0] / gcd, nmq[1] / gcd };
        StringBuilder builder = new StringBuilder(); 
        for (int i = 0; i < nmq[2]; i++)
        {
            var ssee = Console.ReadLine().Split().Select(x => long.Parse(x) - 1).ToArray();
            builder.AppendLine(ssee[1] / sectionLength[ssee[0]] == ssee[3] / sectionLength[ssee[2]] ? "YES" : "NO");
        }
        Console.Write(builder.ToString());
    }


    static long GCD(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            a %= b;
            if (a == 0) return b;
            b %= a;
        }
    }
}
