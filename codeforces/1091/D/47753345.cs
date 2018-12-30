// detail: https://codeforces.com/contest/1091/submission/47753345
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long res = 1;
        long perm = 1;

        for (int i = 1; i <= n; i++)
        {
            res += (perm - 1);
            res *= i;
            res %= 998244353;
            perm *= i;
            perm %= 998244353;
        }
        Console.WriteLine(res);
    }
}
