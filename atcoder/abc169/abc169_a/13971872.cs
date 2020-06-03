// detail: https://atcoder.jp/contests/abc169/submissions/13971872
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
        try
        {
            checked
            {
                var a = Console.ReadLine().Split().Select(long.Parse).ToArray();
                var res = a.Contains(0) ? 0 : a.Aggregate(1L, (x, y) => x * y);
                if (res > 1000000000000000000) throw new Exception();
                Console.WriteLine(res);
            }
        }
        catch
        {
            Console.WriteLine(-1);
        }
    }
}
