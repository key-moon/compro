// detail: https://yukicoder.me/submissions/339852
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
        var ngv = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine((double)((ngv[0] / 5) * ngv[1]) / ngv[2]);
    }
}
