// detail: https://yukicoder.me/submissions/426375
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            long n = nk[0];
            var k = nk[1];
            if (k == 1)
            {
                Console.WriteLine(n - 1);
                continue;
            }
            long layer = 1;
            for (int res = 0; ; res++)
            {
                n -= layer;
                if (n <= 0)
                {
                    Console.WriteLine(res);
                    break;
                }
                layer *= k;
            }
        }
    }
}