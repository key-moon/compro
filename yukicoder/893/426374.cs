// detail: https://yukicoder.me/submissions/426374
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Skip(1).Select(int.Parse).ToArray()).ToArray();

        Console.WriteLine(string.Join(" ", Enumerable.Range(0, a.Max(x => x.Length)).SelectMany(x => a.Where(y => x < y.Length).Select(y => y[x]))));
    }
}