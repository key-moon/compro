// detail: https://atcoder.jp/contests/abc158/submissions/10588018
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 1; i < 100000; i++)
        {
            if (Floor(i * 0.08) == ab[0] && Floor(i * 0.1) == ab[1])
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}