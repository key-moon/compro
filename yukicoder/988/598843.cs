// detail: https://yukicoder.me/submissions/598843
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
        var nmk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nmk[0];
        var m = nmk[1];
        var k = nmk[2];
        var b = Console.ReadLine().Split();
        var op = b[0];
        var row = b.Skip(1).Select(long.Parse).ToArray();
        var col = Enumerable.Repeat(0, n).Select(_ => long.Parse(Console.ReadLine())).ToArray();
        long res = 0;
        if (op == "*") res = (row.Sum() % k) * (col.Sum() % k);
        if (op == "+") res = (row.Sum() % k * col.Length) + (col.Sum() % k * row.Length);
        Console.WriteLine(res % k);
    }
}
