// detail: https://codeforces.com/contest/790/submission/87663444
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var b = Console.ReadLine().Split().Select(x => x == "YES").ToArray();
        List<string> res = new List<string>();
        for (int i = 0; i < k - 1; i++)
        {
            var name = "A" + string.Join("", i.ToString().Select(x => (char)('a' + x - '0')));
            res.Add(name);
        }
        for (int i = k - 1; i < n; i++)
        {
            if (b[i - k + 1]) res.Add("A" + string.Join("", i.ToString().Select(x => (char)('a' + x - '0'))));
            else res.Add(res[i - k + 1]);
        }

        Console.WriteLine(string.Join(" ", res));
    }
}
