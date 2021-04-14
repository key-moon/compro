// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1610/judge/5374170/C#
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
        while (true)
        {
            var mn = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var m = mn[0];
            var n = mn[1];
            if (m == 0) break;
            var valid = new bool[7368792];
            int cur = m;
            int cnt = 0;
            while (true)
            {
                if (!valid[cur])
                {
                    if (n <= cnt) break;
                    cnt++;
                    for (int i = cur; i < valid.Length; i += cur) valid[i] = true;
                }
                cur++;
            }
            Console.WriteLine(cur);
        }
    }
}
