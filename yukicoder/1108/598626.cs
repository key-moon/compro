// detail: https://yukicoder.me/submissions/598626
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
        var nh = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nh[0];
        var h = nh[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(string.Join(" ", a.Select(x => x + h)));
    }
}