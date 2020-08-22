// detail: https://atcoder.jp/contests/abc176/submissions/16128189
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
        Console.WriteLine(Console.ReadLine().Sum(x => x - '0') % 9 == 0 ? "Yes" : "No");
    }
}