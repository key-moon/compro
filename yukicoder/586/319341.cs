// detail: https://yukicoder.me/submissions/319341
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Int = System.Int64;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        int p1 = int.Parse(Console.ReadLine());
        int p2 = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Enumerable.Repeat(0, n).GroupBy(_ => int.Parse(Console.ReadLine())).Sum(x => (p1 + p2) * (x.Count() - 1)));
    }
}
