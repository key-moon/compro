// detail: https://codeforces.com/contest/1284/submission/68164146
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var s1 = Console.ReadLine().Split();
        var s2 = Console.ReadLine().Split();
        int query = int.Parse(Console.ReadLine());
        for (int i = 0; i < query; i++)
        {
            var y = int.Parse(Console.ReadLine()) - 1;
            Console.Write(s1[y % s1.Length]);
            Console.Write(s2[y % s2.Length]);
            Console.WriteLine();
        }
    }
}
