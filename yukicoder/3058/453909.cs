// detail: https://yukicoder.me/submissions/453909
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


public static class P
{
    static void Main()
    {
        var md = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = md[0];
        var d = md[1];
        Console.WriteLine(m == 4 && d == 1 ? 0 : m + d);
    }
}
