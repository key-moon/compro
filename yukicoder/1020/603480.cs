// detail: https://yukicoder.me/submissions/603480
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
        var s = Console.ReadLine();
        var prev = s.Substring(k - 1);
        var after = s.Substring(0, k - 1);
        if ((k - n) % 2 == 0) after = string.Join("", after.Reverse());
        Console.WriteLine(prev + after);
    }
}