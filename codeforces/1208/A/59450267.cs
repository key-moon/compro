// detail: https://codeforces.com/contest/1208/submission/59450267
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var abn = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Solve(abn[0], abn[1], abn[2]));
        }
    }

    static int Solve(int a, int b, int n)
    {
        switch (n % 3)
        {
            case 0:
                return a;
            case 1:
                return b;
            case 2:
                return a ^ b;
        }
        throw new Exception();
    }
}
