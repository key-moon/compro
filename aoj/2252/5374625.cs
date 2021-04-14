// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2252/judge/5374625/C#
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
        var left = "qwertasdfgzxcvb";
        while (true)
        {
            int cnt = 0;
            bool first = true;
            bool last = false;
            foreach (var c in Console.ReadLine())
            {
                if (c == '#') return;
                var cur = left.Contains(c);
                if (first)
                {
                    first = false;
                }
                else
                {
                    if (cur != last) cnt++;
                }
                last = cur;
            }
            Console.WriteLine(cnt);
        }
    }
}
