// detail: https://yukicoder.me/submissions/603299
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
        var t = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var d = new[] { 0, 2, 4, 5, 7, 9, 11 };
        int res = -1;
        for (int i = 0; i < 12; i++)
        {
            if (t.Except(d.Select(x => (x + i) % 12)).Any()) continue;
            if (res != -1)
            {
                Console.WriteLine(-1);
                return;
            }
            res = i;
        }
        Console.WriteLine(res);
    }
}