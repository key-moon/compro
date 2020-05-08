// detail: https://yukicoder.me/submissions/477950
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
        var lrmk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var l = lrmk[0];
        var r = lrmk[1];
        var m = lrmk[2];
        var k = lrmk[3];
        var remain = m - (l * k) % m;
        if (remain == m) remain = 0;

        Console.WriteLine(remain <= (r - l) * k ? "Yes" : "No");
    }
}