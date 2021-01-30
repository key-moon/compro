// detail: https://atcoder.jp/contests/abc190/submissions/19776278
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (abc[0] != abc[1]) Console.WriteLine(abc[0] < abc[1] ? "Aoki" : "Takahashi");
        else Console.WriteLine(abc[2] == 0 ? "Aoki" : "Takahashi");
    }
}