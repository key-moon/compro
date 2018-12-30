// detail: https://codeforces.com/contest/1091/submission/47729190
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
        int[] abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(3 * Min(abc[0] + 1, Min(abc[1], abc[2] - 1)));
    }
}