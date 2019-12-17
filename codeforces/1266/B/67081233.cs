// detail: https://codeforces.com/contest/1266/submission/67081233
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

        Console.WriteLine(string.Join("\n", 
            Console.ReadLine().Split().Select(long.Parse).Select(
                x => (x - 1) % 14 <= 5 && 15 <= x ? "YES" : "NO"
            )
        ));
    }
}