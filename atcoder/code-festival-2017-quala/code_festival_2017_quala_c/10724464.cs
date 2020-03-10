// detail: https://atcoder.jp/contests/code-festival-2017-quala/submissions/10724464
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
        var hw = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var map = Enumerable.Repeat(0, hw[0]).SelectMany(_ => Console.ReadLine()).ToArray();
        var chars = Enumerable.Range(0, 26).Select(x => map.Count(y => y - 'a' == x)).ToArray();
        bool cond;
        if (hw[0] % 2 == 0 && hw[1] % 2 == 0)
        {
            cond = chars.All(x => x % 4 == 0);
        }
        else if (hw[0] % 2 == 0 && hw[1] % 2 == 1 || hw[0] % 2 == 1 && hw[1] % 2 == 0)
        {
            var even = hw[1] % 2 == 1 ? hw[0] : hw[1];
            cond = chars.All(x => x % 2 == 0) && chars.Count(x => x % 4 != 0) <= even / 2;
        }
        else
        {
            var ind = chars.TakeWhile(x => x % 2 == 0).Count();
            if (ind == 26) cond = false;
            else
            {
                chars[ind]--;
                cond = chars.All(x => x % 2 == 0) && chars.Count(x => x % 4 != 0) <= (hw[0] / 2) + (hw[1] / 2);
            }
        }

        Console.WriteLine(cond ? "Yes" : "No");
    }
}
