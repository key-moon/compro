// detail: https://yukicoder.me/submissions/319134
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
        var c = Console.ReadLine().Split().Select(int.Parse).ToList();
        var sum = c.Sum();
        Console.WriteLine(c.Sum(x => x > (float)sum / 10 ? 0 : 30));
    }
}
