// detail: https://yukicoder.me/submissions/426322
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
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(string.Join("", Enumerable.Range(0, 10).Reverse().Take(n).SelectMany(x => Enumerable.Repeat(x, n))));
    }
}
