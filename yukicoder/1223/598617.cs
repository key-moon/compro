// detail: https://yukicoder.me/submissions/598617
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
        var nkt = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = nkt[0];
        var k = nkt[1];
        var t = nkt[2];

        Console.WriteLine(Abs(n) <= t * k ? "Yes" : "No");
    }
}
