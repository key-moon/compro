// detail: https://yukicoder.me/submissions/339840
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
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine((n + 1) / 2 >= Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).GroupBy(x => x).Max(x => x.Count()) ? "YES" : "NO");
    }
}
