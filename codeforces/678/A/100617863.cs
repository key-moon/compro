// detail: https://codeforces.com/contest/678/submission/100617863
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
        var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
        Console.WriteLine((nk[0] / nk[1] + 1) * nk[1]);
    }
}