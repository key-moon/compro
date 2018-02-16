// detail: https://codeforces.com/contest/938/submission/35344946
using System;
using System.Linq;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        Console.ReadLine();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Select(x => Math.Min(x - 1, 1000000 - x)).Max());
    }
}