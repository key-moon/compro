// detail: https://atcoder.jp/contests/panasonic2020/submissions/10842132
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
        var hw = Console.ReadLine().Split().Select(long.Parse).ToArray();
        if (hw[0] == 1 || hw[1] == 1)
        {
            Console.WriteLine(1);
            return;
        }
        Console.WriteLine((hw[0] * hw[1] + 1) / 2);
    }
}
