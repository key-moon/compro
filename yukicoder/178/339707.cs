// detail: https://yukicoder.me/submissions/339707
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
        int n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => { var input = Console.ReadLine().Split().Select(long.Parse).ToArray(); return input[0] + input[1] * 4; }).ToArray();
        var max = a.Max();
        if (a.Any(x => x % 2 != max % 2))
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(a.Select(x => (max - x) / 2).Sum());
    }
}