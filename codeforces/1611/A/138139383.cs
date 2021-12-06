// detail: https://codeforces.com/contest/1611/submission/138139383
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var s = Console.ReadLine();
            if (s.Last() % 2 == 0)
            {
                Console.WriteLine(0);
                continue;
            }
            if (s.First() % 2 == 0)
            {
                Console.WriteLine(1);
                continue;
            }
            if (s.Any(x => x % 2 == 0))
            {
                Console.WriteLine(2);
                continue;
            }
            Console.WriteLine(-1);
        }
    }
}
