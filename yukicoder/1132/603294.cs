// detail: https://yukicoder.me/submissions/603294
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
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = input[0];
        var b = input[1];
        var c = input[2];
        var d = input[3];
        var p = input[4];
        var q = input[5];
        long min = long.MaxValue;
        long minInd = 0;
        long max = long.MinValue;
        long maxInd = 0;
        for (long i = p; i <= q; i++)
        {
            var val = a * i * i * i + b * i * i + c * i + d;
            if (val < min)
            {
                min = val;
                minInd = i;
            }
            if (max < val)
            {
                max = val;
                maxInd = i;
            }
        }
        Console.WriteLine($"{max} {maxInd} {min} {minInd}");
    }
}