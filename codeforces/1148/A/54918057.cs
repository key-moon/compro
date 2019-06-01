// detail: https://codeforces.com/contest/1148/submission/54918057
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
        var abc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine((abc[0] != abc[1] ? 1 : 0) + Min(abc[0], abc[1]) * 2 + abc[2] * 2);
    }
}
