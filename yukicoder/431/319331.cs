// detail: https://yukicoder.me/submissions/319331
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
        Console.WriteLine(a[0] + a[1] + a[2] - a[3] * 1333 >= 2 ? "DEAD" : "SURVIVED");
    }
}
