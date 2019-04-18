// detail: https://yukicoder.me/submissions/339710
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
using System.Runtime.CompilerServices;


static class P
{
    static void Main()
    {
        var xyr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Ceiling(Abs(xyr[0]) + Abs(xyr[1]) + xyr[2] * Sqrt(2) + 0.00001));
    }
}