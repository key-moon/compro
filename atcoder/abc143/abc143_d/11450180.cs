// detail: https://atcoder.jp/contests/abc143/submissions/11450180
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
        var n = int.Parse(Console.ReadLine());
        var l = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
        int res = 0;
        for (int i = 0; i < l.Length; i++)
        {
            for (int j = i + 1; j < l.Length; j++)
            {
                var target = l[i] + l[j];
                var valid = -1;
                var invalid = n;
                while (invalid - valid > 1)
                {
                    var mid = (invalid + valid) / 2;
                    if (l[mid] < target) valid = mid;
                    else invalid = mid;
                }
                res += Max(0, valid - j);
            }
        }
        Console.WriteLine(res);
    }
}
