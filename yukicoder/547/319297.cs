// detail: https://yukicoder.me/submissions/319297
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
        int.Parse(Console.ReadLine());

        var v = Console.ReadLine().Split().Zip(Console.ReadLine().Split(), (x, y) => new Tuple<string, string>(x, y)).Select((x, y) => new Tuple<int, Tuple<string, string>>(y, x)).First(x => x.Item2.Item1 != x.Item2.Item2);
        Console.WriteLine(v.Item1 + 1);
        Console.WriteLine(v.Item2.Item1);
        Console.WriteLine(v.Item2.Item2);
    }
}
