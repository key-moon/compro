// detail: https://yukicoder.me/submissions/339759
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
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(Ceiling(Sqrt(p[0] * p[0] + p[1] * p[1]) * 2 + 0.00001));
    }
}