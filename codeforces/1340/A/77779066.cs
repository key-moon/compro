// detail: https://codeforces.com/contest/1340/submission/77779066
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

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int last = 0;
        var max = 0;
        foreach (var item in a.Reverse())
        {
            if (max < item)
            {
                max = item;
            }
            else
            {
                if (last - 1 != item)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            last = item;
        }
        Console.WriteLine("Yes");
    }
}
