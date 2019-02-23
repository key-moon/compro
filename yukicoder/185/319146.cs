// detail: https://yukicoder.me/submissions/319146
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
        var res = Enumerable.Repeat(0, int.Parse(Console.ReadLine())).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => x[1] - x[0]).Distinct().ToArray();
        Console.WriteLine(res.Length == 1 && res.First() > 0 ? res.First() : -1);
    }
}
