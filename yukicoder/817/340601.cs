// detail: https://yukicoder.me/submissions/340601
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        long k = nk[1];
        List<Tuple<int, int>> imos = new List<Tuple<int, int>>();
        foreach (var ab in Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray())
        {
            imos.Add(new Tuple<int, int>(ab[0], 1));
            imos.Add(new Tuple<int, int>(ab[1] + 1, -1));
        }

        long count = 0;
        long last = 0;
        foreach (var item in imos.OrderBy(x => x.Item1))
        {
            if (count != 0 && k <= (item.Item1 - last) * count)
            {
                Console.WriteLine(last + (k - 1) / count);
                return;
            }
            k -= (item.Item1 - last) * count;
            count += item.Item2;
            last = item.Item1;
        }
    }
}
