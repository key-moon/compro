// detail: https://yukicoder.me/submissions/339744
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;


static class P
{
    static void Main()
    {
        Console.WriteLine(Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Count(x => x == '^')).GroupBy(x => x).OrderBy(x => x.Count()).ThenBy(x => x.Key).Last().Key);
    }
}