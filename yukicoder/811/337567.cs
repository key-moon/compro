// detail: https://yukicoder.me/submissions/337567
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var factorOfN = Factors(nk[0]).ToArray();
        long max = 0;
        int maxI = 0;
        for (int i = 1; i < nk[0]; i++)
        {
            int counter = 0;
            int ptr = 0;
            var factors = Factors(i).ToArray();
            foreach (var item in factors)
            {
                while (factorOfN[ptr] < item)
                {
                    ptr++;
                    if (ptr >= factorOfN.Length) goto end;
                }
                if (factorOfN[ptr] == item)
                {
                    counter++;
                    ptr++;
                    if (ptr >= factorOfN.Length) goto end;
                }
            }
            end:;
            if (counter < nk[1]) continue;
            var v = factors.GroupBy(x => x).Aggregate(1L, (x, y) => x * (y.Count() + 1));
            if (max < v)
            {
                maxI = i;
                max = v;
            }
        }
        Console.WriteLine(maxI);
    }

    static IEnumerable<long> Factors(long n)
    {
        while (n % 2 == 0)
        {
            n /= 2;
            yield return 2;
        }
        long i = 3;
        while (i * i <= n)
        {
            if (n % i == 0)
            {
                n /= i;
                yield return i;
            }
            else i += 2;
        }
        if (n != 1) yield return n;
    }
}
