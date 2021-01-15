// detail: https://yukicoder.me/submissions/603471
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
        var input = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var x = input[2];
        var n = input[3];
        Console.WriteLine(x % 2 == 0 ? $"0 {n / 2}" : $"{n / 2} 0");
    }
}