// detail: https://yukicoder.me/submissions/426324
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abc[0];
        var b = abc[1];
        var c = abc[2];
        Console.WriteLine(a * ((double)c / b));
    }
}
