// detail: https://codeforces.com/contest/1296/submission/70251820
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var converted = s.Select(x => x == 'L' ? 1000000L : x == 'R' ? -1000000L : x == 'U' ? 1L : -1L).ToArray();
        var accum = new long[n + 1];

        for (int i = 0; i < converted.Length; i++)
            accum[i + 1] = accum[i] + converted[i];
        
        var curRes = "-1";
        var min = int.MaxValue;
        Dictionary<long, int> last = new Dictionary<long, int>();
        for (int i = 0; i < accum.Length; i++)
        {
            if (last.ContainsKey(accum[i]))
            {
                var dist = i - last[accum[i]];
                if (min > dist)
                {
                    min = dist;
                    curRes = $"{last[accum[i]]} {i}";
                }
            }
            else
            {
                last.Add(accum[i], 0);
            }
            last[accum[i]] = i + 1;
        }
        Console.WriteLine(curRes);
    }
}
