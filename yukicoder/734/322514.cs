// detail: https://yukicoder.me/submissions/322514
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
        var abc = Console.ReadLine().Split().Select(double.Parse).ToList();
        Console.WriteLine(abc[0] * 60 - abc[1] <= 0 ? "-1" : ((long)Ceiling(abc[2] / (abc[0] * 60 - abc[1]) * 3600)).ToString());
    }
}
