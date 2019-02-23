// detail: https://yukicoder.me/submissions/319345
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
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToList();
        Console.WriteLine(a.Distinct().Count() == a.Count() && a.Zip(a.Skip(1), (x, y) => y - x).Distinct().Count() == 1 ? "YES" : "NO"); ;
    }
}