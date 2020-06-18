// detail: https://atcoder.jp/contests/indeednow-qualb/submissions/14460284
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
        var t = Console.ReadLine();
        if (s == t)
        {
            Console.WriteLine(0);
            return;
        }
        for (int i = 1; i <= s.Length; i++)
        {
            s = s.Last() + s.Substring(0, s.Length - 1);
            if (s == t)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}