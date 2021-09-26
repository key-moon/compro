// detail: https://atcoder.jp/contests/abc220/submissions/26127455
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
        for (int i = abc[0]; i <= abc[1]; i++)
        {
            if (i % abc[2] == 0)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}