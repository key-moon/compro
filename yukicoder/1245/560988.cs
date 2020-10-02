// detail: https://yukicoder.me/submissions/560988
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var s = Console.ReadLine();

        var reses = new[] { new long[32], new long[32] };

        for (int type = 0; type <= 1; type++)
        {
            for (int i = 0; i < 32; i++)
            {
                var res = 0L;
                var current = type;
                for (int j = 0; j < n; j++)
                {
                    var bit = (a[j] >> i) & 1;
                    var c = s[j];
                    var next = c == '0' ? (current & bit) : (current | bit);
                    res += Abs(next - current);
                    current = next;
                }
                reses[type][i] = res * (1 << i);
            }
        }
        
        var queries = Console.ReadLine().Split().Select(int.Parse).ToArray();

        foreach (var query in queries)
        {
            var res = 0L;
            for (int i = 0; i < 32; i++)
            {
                res += reses[query >> i & 1][i];
            }
            Console.WriteLine(res);
        }
    }
}