// detail: https://yukicoder.me/submissions/339833
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
        Console.WriteLine(string.Join("\n", Enumerable.Range(0, 3).Select(x => new Tuple<int[], int>(Console.ReadLine().Split().Select(int.Parse).ToArray(), x)).OrderByDescending(x => x.Item1[0]).ThenBy(x => x.Item1[1]).Select(x => (char)('A' + x.Item2))));
    }
}
