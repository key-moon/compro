// detail: https://yukicoder.me/submissions/339747
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
        List<long> res = new List<long>();
        long pow2 = 1L;
        for (int i = 0; i <= n; i++)
        {
            var pow5 = 1L;
            for (int j = 0; j <= n; j++)
            {
                res.Add(pow2 * pow5);
                pow5 *= 5;
            }
            pow2 *= 2;
        }
        Console.WriteLine(string.Join("\n", res.OrderBy(x => x)));
    }
}