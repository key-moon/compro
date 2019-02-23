// detail: https://yukicoder.me/submissions/319192
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
        var c = Console.ReadLine().Split().Select(int.Parse).Distinct().OrderBy(x => x).ToList();   
        Console.WriteLine(c.Count == 1 ? 0 : c.Zip(c.Skip(1), (x, y) => y - x).Min());
    }
}
