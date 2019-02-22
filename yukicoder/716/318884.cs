// detail: https://yukicoder.me/submissions/318884
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
        int.Parse(Console.ReadLine());
        var v = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(v.Zip(Enumerable.Repeat(int.MinValue, 1).Concat(v), (x, y) => x - y).Min());
        Console.WriteLine(v.Max() - v.Min());
    }
}
