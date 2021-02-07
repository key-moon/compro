// detail: https://codeforces.com/contest/1479/submission/106791859
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = 0;
        int expose = -1;
        int cur = -1;
        int streak = 0;
        int exposed = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != cur)
            {
                var curRes = Min(streak, expose == cur ? 1 : 2);
                res += curRes;
                if (curRes == 2)
                {
                    expose = cur;
                    exposed = 2;
                }
                else
                {
                    if (expose != cur) exposed--;
                    else exposed++;
                    if (exposed <= 0) expose = -1;
                }
                streak = 0;
            }
            cur = a[i];
            streak++;
        }
        res += Min(streak, expose == cur ? 1 : 2);
        Console.WriteLine(res);
    }
}
