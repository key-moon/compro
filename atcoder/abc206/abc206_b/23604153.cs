// detail: https://atcoder.jp/contests/abc206/submissions/23604153
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
        var n = int.Parse(Console.ReadLine());
        int i = 1;
        int sum = 0;
        while (true)
        {
            sum += i;
            if (n <= sum)
            {
                Console.WriteLine(i);
                return;
            }
            i++;
        }
    }
}