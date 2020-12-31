// detail: https://yukicoder.me/submissions/598646
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
using static System.Math;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).OrderBy(x => x).ToArray();

        Console.WriteLine(a.Length <= 1 || 2 <= a.Zip(a.Skip(1), (x, y) => y - x).Min() ? 1 : 2);
    }
}
