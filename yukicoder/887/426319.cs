// detail: https://yukicoder.me/submissions/426319
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
        var n = long.Parse(Console.ReadLine());
        int i = 0;
        var max = n;
        for (; n != 1; i++)
        {
            if (n % 2 == 0) n /= 2;
            else { n *= 3; n++; }
            max = Max(max, n);
        }
        Console.WriteLine(i);
        Console.WriteLine(max);
    }
}
