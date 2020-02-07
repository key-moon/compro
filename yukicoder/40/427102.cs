// detail: https://yukicoder.me/submissions/427102
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
        int d = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = a.Length - 1; i >= 3; i--)
        {
            a[i - 2] += a[i];
            a[i] = 0;
        }
        var res = a.Reverse().SkipWhile(x => x == 0).Reverse().ToArray();
        Console.WriteLine(Max(res.Length - 1, 0));
        Console.WriteLine(res.Length == 0 ? "0" : string.Join(" ", res));
    }
}