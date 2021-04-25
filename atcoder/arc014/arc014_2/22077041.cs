// detail: https://atcoder.jp/contests/arc014/submissions/22077041
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
        int n = int.Parse(Console.ReadLine());
        HashSet<string> set = new HashSet<string>();
        var prev = Console.ReadLine();
        set.Add(prev);
        for (int i = 1; i < n; i++)
        {
            var s = Console.ReadLine();
            if (prev[^1] != s[0] || !set.Add(s))
            {
                Console.WriteLine(i % 2 == 0 ? "LOSE" : "WIN");
                return;
            }
            prev = s;
        }
        Console.WriteLine("DRAW");
    }
}