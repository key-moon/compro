// detail: https://atcoder.jp/contests/m-solutions2020/submissions/16426278
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
        var k = int.Parse(Console.ReadLine());
        for (int i = 0; i < k; i++)
        {
            if (abc[0] >= abc[1]) abc[1] *= 2;
            else abc[2] *= 2;
        }

        Console.WriteLine(abc[0] < abc[1] && abc[1] < abc[2] ? "Yes" : "No");
    }
}
