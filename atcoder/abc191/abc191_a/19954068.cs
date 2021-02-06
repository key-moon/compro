// detail: https://atcoder.jp/contests/abc191/submissions/19954068
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
        var vtsd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (vtsd[3] < vtsd[0] * vtsd[1] || vtsd[0] * vtsd[2] < vtsd[3]) Console.WriteLine("Yes");
        else Console.WriteLine("No");
    }
}
