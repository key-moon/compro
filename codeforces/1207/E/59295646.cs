// detail: https://codeforces.com/contest/1207/submission/59295646
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var q1 = Enumerable.Range(1, 100).Select(x => (x << 7)).ToArray();
        var q2 = Enumerable.Range(1, 100).Select(x => x).ToArray();
        Console.WriteLine("? " + string.Join(" ", q1));
        var a1 = int.Parse(Console.ReadLine());
        Console.WriteLine("? " + string.Join(" ", q2));
        var a2 = int.Parse(Console.ReadLine());

        var mask1 = (1 << 7) - 1;
        var mask2 = ((1 << 7) - 1) << 7;
        Console.WriteLine("! " + ((a1 & mask1) | (a2 & mask2)).ToString());
    }
}
