// detail: https://atcoder.jp/contests/arc117/submissions/21867344
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        int[] seq = null;
        if (a == b) seq = Enumerable.Range(1, a).Concat(Enumerable.Range(1, b).Select(x => -x)).ToArray();
        else
        {
            if (a < b)
                seq = Enumerable.Range(1, a - 1).Concat(Enumerable.Range(1, b).Select(x => -x)).ToArray();
            if (a > b)
                seq = Enumerable.Range(1, a).Concat(Enumerable.Range(1, b - 1).Select(x => -x)).ToArray();
            seq = seq.Append(-seq.Sum()).ToArray();
        }
        Console.WriteLine(string.Join(" ", seq));
    }
}