// detail: https://yukicoder.me/submissions/477731
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (a.Count(x => x >= 0) == 0) Console.WriteLine(a.Max());
        else Console.WriteLine(a.OrderByDescending(x => x).TakeWhile(x => x >= 0).Take(k).Sum());
    }
}