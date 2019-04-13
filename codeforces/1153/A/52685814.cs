// detail: https://codeforces.com/contest/1153/submission/52685814
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        var nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var minTime = int.MaxValue;
        var res = -1;
        for (int i = 0; i < nt[0]; i++)
        {
            var sd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var time = sd[0];
            while (time < nt[1]) time += sd[1];
            if (time < minTime)
            {
                minTime = time;
                res = i;
            }
        }
        Console.WriteLine(res + 1);
    }
}

