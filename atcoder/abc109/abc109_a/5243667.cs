// detail: https://atcoder.jp/contests/abc109/submissions/5243667
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine((ab[0] * ab[1]) % 2 == 1 ? "Yes" : "No");
    }
}
