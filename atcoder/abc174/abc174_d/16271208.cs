// detail: https://atcoder.jp/contests/abc174/submissions/16271208
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
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var ptra = 0;
        var ptrb = n - 1;
        int res = 0;
        while (true)
        {
            while (ptra < s.Length && s[ptra] == 'R') ptra++;
            while (0 <= ptrb && s[ptrb] == 'W') ptrb--;
            if (ptra >= ptrb) break;
            ptra++;
            ptrb--;
            res++;
        }
        Console.WriteLine(res);
    }
}
