// detail: https://codeforces.com/contest/1013/submission/40939913
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] x = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] y = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(x.Sum() >= y.Sum() ? "Yes" : "No");
    }
}