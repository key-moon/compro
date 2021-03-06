// detail: https://atcoder.jp/contests/abc129/submissions/5836170
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var pqr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(pqr.Sum() - pqr.Max());
    }
}
