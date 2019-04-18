// detail: https://yukicoder.me/submissions/339855
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
        var t = int.Parse(Console.ReadLine());
        Console.WriteLine(string.Join("\n", Enumerable.Repeat(0, t).Select(_ => Convert(Console.ReadLine().Select(x => x - '0').ToArray()))));
    }
    static int Convert(int[] i) => i.Length == 1 ? i[0] : Convert(i.Zip(i.Skip(1), (x, y) => (x + y) >= 10 ? (x + y) % 10 + 1 : x + y).ToArray());
}
