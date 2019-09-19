// detail: https://codeforces.com/contest/1221/submission/60858693
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var cmx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Solve(cmx[0], cmx[1], cmx[2]));
        }
    }
    static int Solve(int c, int m, int x)
    {
        int valid = 0;
        int invalid = Min(c, m) + 1;
        while (invalid - valid > 1)
        {
            var mid = (valid + invalid) / 2;
            if (mid <= c && mid <= m && mid * 3 <= c + m + x) valid = mid;
            else invalid = mid;
        }
        return valid;
    }
}
