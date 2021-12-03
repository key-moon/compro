// detail: https://atcoder.jp/contests/abc230/submissions/27673880
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
        var s = Console.ReadLine();
        var tlen = s.Length / 3 * 3 + 6;
        for (int b = 0; b < (1 << tlen); b++)
        {
            string t = "";
            for (int i = 0; i < tlen; i++)
            {
                t += (b >> i & 1) == 1 ? 'o' : 'x';
            }
            if (Regex.IsMatch(t, "^(oxx)+$") && t.Contains(s))
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        Console.WriteLine("No");
    }
}
