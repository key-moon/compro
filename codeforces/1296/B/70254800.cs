// detail: https://codeforces.com/contest/1296/submission/70254800
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Console.WriteLine(Solve(int.Parse(Console.ReadLine())));
        }
    }
    static int Solve(int n)
    {
        if (n < 10) return n;
        int rem;
        var div = Math.DivRem(n, 10, out rem);
        return div * 10 + Solve(div + rem);
    }
}
