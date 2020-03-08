// detail: https://atcoder.jp/contests/hitachi2020/submissions/10669405
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var abm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var min = Enumerable.Repeat(0, abm[2]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Min(x => a[x[0] - 1] + b[x[1] - 1] - x[2]);
        Console.WriteLine(Min(a.Min() + b.Min(), min));
    }
}
