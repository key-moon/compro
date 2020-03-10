// detail: https://atcoder.jp/contests/keyence2019/submissions/10724495
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

        Console.WriteLine(
            Regex.IsMatch(s, "^.*keyence$") ||
            Regex.IsMatch(s, "^k.*eyence$") ||
            Regex.IsMatch(s, "^ke.*yence$") ||
            Regex.IsMatch(s, "^key.*ence$") ||
            Regex.IsMatch(s, "^keye.*nce$") ||
            Regex.IsMatch(s, "^keyen.*ce$") ||
            Regex.IsMatch(s, "^keyenc.*e$") ||
            Regex.IsMatch(s, "^keyence.*$") ? "YES" : "NO");
    }
}
