// detail: https://codeforces.com/contest/980/submission/38025472
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        string str = Console.ReadLine();
        int count = str.Count(x => x == 'o');
        Console.WriteLine(count == 0 || str.Length == ((str.Length / count) * count) ? "YES" : "NO");
    } 
}