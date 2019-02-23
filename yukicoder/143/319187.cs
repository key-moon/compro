// detail: https://yukicoder.me/submissions/319187
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
        var knf = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(Max(knf[0] * knf[1] - Console.ReadLine().Split().Select(int.Parse).Sum(), -1));
    }
}
