// detail: https://codeforces.com/contest/1150/submission/53504795
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
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;


static class P
{
    static void Main()
    {
        var nmr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var buy = Console.ReadLine().Split().Select(int.Parse).Min();
        var cell = Console.ReadLine().Split().Select(int.Parse).Max();
        Console.WriteLine(buy < cell ? (nmr[2] / buy) * cell + nmr[2] % buy : nmr[2]);
    }
}
