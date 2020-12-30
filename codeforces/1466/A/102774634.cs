// detail: https://codeforces.com/contest/1466/submission/102774634
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
        int n = int.Parse(Console.ReadLine());
        var x = Console.ReadLine().Split().Select(int.Parse).ToArray();
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < x.Length; i++)
        {
            for (int j = i + 1; j < x.Length; j++)
            {
                set.Add(Abs(x[j] - x[i]));
            }
        }
        set.Remove(0);
        Console.WriteLine(set.Count);
    }
}
