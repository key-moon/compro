// detail: https://yukicoder.me/submissions/426356
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        try
        {
            var abc = Enumerable.Repeat(0, n).Select(_ => long.Parse(Console.ReadLine())).ToArray();
            Console.WriteLine(abc.Select(x => abc.Sum() - x).Distinct().OrderByDescending(x => x).Skip(1).First());
        }
        catch
        {
            Console.WriteLine(@"""assert""");
        }
    }
}