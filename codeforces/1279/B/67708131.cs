// detail: https://codeforces.com/contest/1279/submission/67708131
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
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
            Solve();
    }
    static void Solve()
    {
        var ns = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = ns[0];
        long s = ns[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long curMax = 0;
        int curMaxInd = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (curMax < a[i])
            {
                curMax = a[i];
                curMaxInd = i + 1;
            }
            if (s < a[i])
            {
                if (a[i] <= s + curMax)
                {
                    Console.WriteLine(curMaxInd);
                    return;
                }
                break;
            }
            s -= a[i];
        }
        Console.WriteLine(0);
    }
}
