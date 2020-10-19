// detail: https://codeforces.com/contest/1426/submission/95959596
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();

        }

    }
    static void Solve()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        HashSet<string> s = new HashSet<string>();
        bool hasDiag = false;
        bool hasOther = false;
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            s.Add($"{ab[0]}{ab[1]}{cd[0]}{cd[1]}");
            if (ab[1] == cd[0]) hasDiag = true;
            if (s.Contains($"{ab[0]}{cd[0]}{ab[1]}{cd[1]}")) hasOther = true;
        }
        if (m % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }
        if ((m == 2 || hasOther) && hasDiag) Console.WriteLine("YES");
        else Console.WriteLine("NO");
    }
}
