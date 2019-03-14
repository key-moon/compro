// detail: https://yukicoder.me/submissions/322508
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
        var rd = Console.ReadLine().Split().Select(double.Parse).ToList();
        Console.WriteLine(Sqrt(rd[1] * rd[1] - rd[0] * rd[0]));
    }
}
