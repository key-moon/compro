// detail: https://yukicoder.me/submissions/319339
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        var b = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(Abs(a[0] - b[0]) / 2.0 + Abs(a[1] - b[1]) / 2.0);
    }
}
