// detail: https://yukicoder.me/submissions/319094
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine((a[0] + 3 - a[1]) % 3 == 2 ? "Won" : a[0] == a[1] ? "Drew" : "Lost");
    }
}
