// detail: https://yukicoder.me/submissions/598689
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var l = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        for (int i = 0; i < k; i++)
        {
            Console.WriteLine($"1 1 1 {l[i]}");
        }
    }
}
