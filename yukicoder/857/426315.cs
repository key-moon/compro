// detail: https://yukicoder.me/submissions/426315
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using System.Threading.Tasks;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var xyz = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var x = xyz[0];
        var y = xyz[1];
        var z = xyz[2];
        Console.WriteLine(z - (x <= z ? 1 : 0) - (y <= z ? 1 : 0));
    }
}
