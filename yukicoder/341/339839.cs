// detail: https://yukicoder.me/submissions/339839
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

        Console.WriteLine(Console.ReadLine().Aggregate(new Tuple<int, int>(0, 0), (x, y) => y == '…' ? new Tuple<int, int>(x.Item1 + 1, Max(x.Item1 + 1, x.Item2)) : new Tuple<int, int>(0, x.Item2)).Item2);
    }
}
