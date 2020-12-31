// detail: https://yukicoder.me/submissions/598622
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hw[0];
        var w = hw[1];
        var mat = Enumerable.Repeat(0, h).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var flatten = mat.SelectMany(x => x).OrderBy(x => x).ToArray();
        for (int i = 0; i < flatten.Length; i += w)
        {
            Console.WriteLine(string.Join(" ", flatten.Skip(i).Take(w)));
        }
    }
}