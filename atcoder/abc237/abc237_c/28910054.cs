// detail: https://atcoder.jp/contests/abc237/submissions/28910054
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
        var s = Console.ReadLine();
        var head = s.Length - s.TrimStart('a').Length;
        var tail = s.Length - s.TrimEnd('a').Length;
        string t = s.Trim('a');
        var res = t.Reverse().SequenceEqual(t) && (head <= tail);
        Console.WriteLine(res ? "Yes" : "No");

    }
}
