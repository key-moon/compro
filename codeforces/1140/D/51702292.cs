// detail: https://codeforces.com/contest/1140/submission/51702292
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long res = 0;
        for (int i = 2; i <= n - 1; i++) res += i * (i + 1);
        Console.WriteLine(res);
    }
}
