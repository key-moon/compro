// detail: https://yukicoder.me/submissions/426347
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
        var lrn = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var n = lrn[2];
        var l = lrn[0] + n - 1;
        var r = lrn[1] + n;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine((r - i) / n - (l - i) / n);
        }
    }
}
