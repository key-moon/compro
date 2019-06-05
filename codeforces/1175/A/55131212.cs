// detail: https://codeforces.com/contest/1175/submission/55131212
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        int q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            var nk = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var n = nk[0];
            var k = nk[1];
            var step = 0L;
            while (true)
            {
                if (n < k)
                {
                    step += n;
                    break;
                }
                step += n % k;
                n /= k;
                step++;
            }
            Console.WriteLine(step);
        }
    }
}
