// detail: https://yukicoder.me/submissions/603277
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
        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nd[0];
        var d = nd[1];
        var x = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var v = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var sum = v.Sum();
        Console.WriteLine((d + sum - 1) / sum);
    }
}