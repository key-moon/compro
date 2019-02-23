// detail: https://yukicoder.me/submissions/319214
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
        var a = Console.ReadLine().Split();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).GroupBy(x => x).OrderByDescending(x => x.Count()).ThenByDescending(x => x.Key).First().Key);
    }
}
