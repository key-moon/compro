// detail: https://yukicoder.me/submissions/612259
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
        var xy1 = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var x1 = xy1[0];
        var y1 = xy1[1];
        var xy2 = Console.ReadLine().Split().Select(double.Parse).ToArray();
        var x2 = xy2[0];
        var y2 = xy2[1];
        Console.WriteLine((y2 - y1) * (x1 / (x1 + x2)) + y1);
    }
}
