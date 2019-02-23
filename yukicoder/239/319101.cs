// detail: https://yukicoder.me/submissions/319101
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
        int n = int.Parse(Console.ReadLine());
        var counts = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split()).Aggregate(Enumerable.Repeat(0, n), (x, y) => x.Zip(y, (z, w) => z + (w == "nyanpass" ? 1 : 0))).ToList();
        Console.WriteLine(counts.Count(x => x == n - 1) != 1 ? -1 : counts.IndexOf(n - 1) + 1);
    }
}
