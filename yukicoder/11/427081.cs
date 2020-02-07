// detail: https://yukicoder.me/submissions/427081
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
        int w = int.Parse(Console.ReadLine());
        var h = long.Parse(Console.ReadLine());
        var n = int.Parse(Console.ReadLine());
        var hand = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var markKinds = hand.Select(x => x[0]).Distinct().Count();
        var valueKinds = hand.Select(x => x[1]).Distinct().Count();
        Console.WriteLine(markKinds * h + valueKinds * w - markKinds * valueKinds - n);
    }
}
