// detail: https://yukicoder.me/submissions/612267
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
        var s = Console.ReadLine().Split();
        var dig = s.Max(x => x.Length);
        s[0] = s[0].PadLeft(dig, '0');
        s[1] = s[1].PadLeft(dig, '0');
        var max = s[0];
        for (int i = 0; i < dig; i++)
        {
            if (s[0][i] == '7' && s[1][i] == '4')
            {
                max = s[1];
                break;
            }
            if (s[0][i] == '4' && s[1][i] == '7')
            {
                max = s[0];
                break;
            }
            if (s[0][i] < s[1][i])
            {
                max = s[1];
                break;
            }
            if (s[0][i] > s[1][i])
            {
                max = s[0];
                break;
            }
        }
        Console.WriteLine(max);
    }
}
