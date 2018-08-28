// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0360/judge/3111842/C#
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Math;

class P
{
    static void Main()
    {
        int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] sf = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (Max(sf[0], ab[0]) < Min(sf[1], ab[1]))
            {
                Console.WriteLine(1);
                return;
            }
        }
        Console.WriteLine(0);
    }
}
