// detail: https://codeforces.com/contest/1270/submission/67879644
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        Console.ReadLine();
        var a = Console.ReadLine().Split().Select(int.Parse).Max();
        var b = Console.ReadLine().Split().Select(int.Parse).Max();

        Console.WriteLine(a > b ? "YES" : "NO");
    }
}
