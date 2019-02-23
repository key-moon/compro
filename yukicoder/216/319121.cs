// detail: https://yukicoder.me/submissions/319121
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
        Console.ReadLine();
        Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Zip(Console.ReadLine().Split().Select(int.Parse), (x, y) => new Tuple<int, int>(x, y)).GroupBy(x => x.Item2).OrderByDescending(x => x.Sum(y => y.Item1)).ThenBy(x => x.Key).First().Key == 0 ? "YES" : "NO");
    }
}
