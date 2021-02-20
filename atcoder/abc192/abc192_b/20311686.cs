// detail: https://atcoder.jp/contests/abc192/submissions/20311686
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
        string s = Console.ReadLine();
        Console.WriteLine(s.Select((x, ind) => char.IsUpper(x) == (ind % 2 == 1)).All(x => x) ? "Yes" : "No");
    }
}