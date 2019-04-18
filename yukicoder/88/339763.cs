// detail: https://yukicoder.me/submissions/339763
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
        Console.WriteLine(new string[] { "oda", "yukiko" }[((Console.ReadLine() == "oda" ? 0 : 1) + Enumerable.Repeat(0, 8).Select(_ => Console.ReadLine().Count(x => x != '.')).Sum()) % 2]);
    }
}