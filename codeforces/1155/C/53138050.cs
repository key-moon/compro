// detail: https://codeforces.com/contest/1155/submission/53138050
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var events = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var pcand = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var gcd = events.Zip(events.Skip(1), (x, y) => y - x).Aggregate(0L, GCD);
        for (int i = 0; i < pcand.Length; i++)
        {
            if (gcd % pcand[i]== 0)
            {
                Console.WriteLine("YES");
                Console.WriteLine($"{events[0]} {i + 1}");
                return;
            }
        }
        Console.WriteLine("NO");
    }

    static long GCD(long a, long b)
    {
        while (true)
        {
            if (a > b)
            {
                if (b == 0) return a;
                a %= b;
            }
            else
            {
                if (a == 0) return b;
                b %= a;
            }
        }
    }
}
