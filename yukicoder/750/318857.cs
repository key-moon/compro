// detail: https://yukicoder.me/submissions/318857
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

class P
{
    static void Main()
    {
        Console.WriteLine(string.Join("\n", Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList()).OrderByDescending(x => (float)x[0] / x[1]).Select(x => $"{x[0]} {x[1]}")));
    }
}
