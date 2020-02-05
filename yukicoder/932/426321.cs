// detail: https://yukicoder.me/submissions/426321
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
        var s = Console.ReadLine();
        Console.WriteLine(s.Contains('L') || s.Contains('W') ? "Failed..." : "Done!");
    }
}
