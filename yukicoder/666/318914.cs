// detail: https://yukicoder.me/submissions/318914
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
        var ab = Console.ReadLine().Split().Select(long.Parse).ToList();
        Console.WriteLine(ab[0] * ab[1] % 1000000007);
    }
}
