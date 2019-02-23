// detail: https://yukicoder.me/submissions/319283
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
        Console.WriteLine(string.Join("\n", Enumerable.Repeat(0, 3).Select((_, y) => new Tuple<int, int>(int.Parse(Console.ReadLine()), y)).OrderByDescending(x => x).Select(x => (char)('A' + x.Item2))));
    }
}
