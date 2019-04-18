// detail: https://yukicoder.me/submissions/339783
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            var gd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (gd[0] - gd[1] * 30000 >= 500000)
            {
                Console.WriteLine("YES");
                Console.WriteLine(string.Join("\n", Enumerable.Repeat(i, 6)));
                return;
            }
        }
        Console.WriteLine("NO");
    }
}