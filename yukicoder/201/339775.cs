// detail: https://yukicoder.me/submissions/339775
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
        var a = Console.ReadLine().Split();
        var b = Console.ReadLine().Split();
        var pa = a[1].PadLeft(100010, '0');
        var pb = b[1].PadLeft(100010, '0');
        Console.WriteLine(pa.CompareTo(pb) > 0 ? a[0] : pa.CompareTo(pb) < 0 ? b[0] : "-1");
    }
}