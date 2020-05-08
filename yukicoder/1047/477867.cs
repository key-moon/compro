// detail: https://yukicoder.me/submissions/477867
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
        var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        long n = 0;
        for (int i = 1; i <= 2; i++)
        {
            n = n * a + b;
            if (n == 0)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}