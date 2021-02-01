// detail: https://yukicoder.me/submissions/612311
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
        List<long> fibs = new List<long>() { 1, 1 };
        while (fibs.Last() <= 1e17) fibs.Add(fibs[fibs.Count - 2] + fibs[fibs.Count - 1]);
        var a = Enumerable.Repeat(0, 5).Select(_ => long.Parse(Console.ReadLine())).Reverse().ToArray();
        var seq = fibs.SkipWhile(x => x != a[0]).ToArray();
        if (a[0] == 1 && a[1] != 1) seq = seq.Skip(1).ToArray();
        Console.WriteLine(a.Zip(seq, (x, y) => x == y).TakeWhile(x => x).Count());
    }
}