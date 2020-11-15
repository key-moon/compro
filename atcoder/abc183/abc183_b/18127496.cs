// detail: https://atcoder.jp/contests/abc183/submissions/18127496
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
        var ssgg = Console.ReadLine().Split().Select(long.Parse).ToArray();
        double xdist = ssgg[2] - ssgg[0];
        double ydist = ssgg[3] + ssgg[1];
        Console.WriteLine(ssgg[1] / ydist * xdist + ssgg[0]);
    }
}
