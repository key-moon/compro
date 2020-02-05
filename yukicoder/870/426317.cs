// detail: https://yukicoder.me/submissions/426317
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
        var a = "2 8";
        var b = "3 9";
        var c = "7 9";
        for (int i = 0; i < n; i++)
        {
            var q = Console.ReadLine().Split();
            var before = $"{q[0]} {q[1]}";
            var after = $"{q[2]} {q[3]}";
            if (a == before) a = after;
            if (b == before) b = after;
            if (c == before) c = after;
        }
        if (a == "5 8" && b == "4 8" && c == "6 8") Console.WriteLine("YES");
        else Console.WriteLine("NO");
    }
}
