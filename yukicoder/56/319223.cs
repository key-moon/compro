// detail: https://yukicoder.me/submissions/319223
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
        var lk = Console.ReadLine().Split().Select(int.Parse).ToList();
        Console.WriteLine(lk[0] * (100 + lk[1]) / 100);
    }
}
