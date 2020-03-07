// detail: https://atcoder.jp/contests/abc158/submissions/10593082
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
        var s = Console.ReadLine();
        Console.WriteLine(s.GroupBy(x => x).Count() == 2 ? "Yes" : "No");
    }
}