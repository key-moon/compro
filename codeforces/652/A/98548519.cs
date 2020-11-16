// detail: https://codeforces.com/contest/652/submission/98548519
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
        var h = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var h1 = h[0];
        var h2 = h[1];
        var ab = Console.ReadLine().Split().Select(long.Parse).ToArray();
        h1 += ab[0] * 8;
        if (h2 <= h1)
        {
            Console.WriteLine(0);
            return;
        }
        if (ab[0] <= ab[1])
        {
            Console.WriteLine(-1);
            return;
        }
        int day = 1;
        while (true)
        {
            h1 -= ab[1] * 12;
            h1 += ab[0] * 12;
            if (h2 <= h1)
            {
                Console.WriteLine(day);
                return;
            }
            day++;
        }
    }
}
