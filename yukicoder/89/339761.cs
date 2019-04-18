// detail: https://yukicoder.me/submissions/339761
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int c = int.Parse(Console.ReadLine());
        var inout = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var r = ((inout[1] - inout[0]) / 2.0);
        var R = inout[0] + r;
        Console.WriteLine(2 * PI * PI * r * r * R * c);
    }
}