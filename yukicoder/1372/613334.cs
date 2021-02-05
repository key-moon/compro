// detail: https://yukicoder.me/submissions/613334
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
        var n = long.Parse(Console.ReadLine());
        Console.WriteLine(MSB(n));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long MSB(long s) { s |= s >> 1; s |= s >> 2; s |= s >> 4; s |= s >> 8; s |= s >> 16; s |= s >> 32; return (s + 1) >> 1; }
}
