// detail: https://codeforces.com/contest/652/submission/98555901
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var pos = a.Select((x, y) => (x, y)).OrderBy(x => x.x).Select(x => x.y).ToArray();
        //その後に登場する一番手前の場所
        int[] sectionEnd = Enumerable.Repeat(n, n).ToArray();
        for (int i = 0; i < m; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var p = ab[0] - 1;
            var q = ab[1] - 1;
            var ppos = pos[p];
            var qpos = pos[q];
            if (ppos > qpos) (ppos, qpos) = (qpos, ppos);
            sectionEnd[ppos] = Min(sectionEnd[ppos], qpos);
        }
        for (int i = sectionEnd.Length - 1; i >= 1; i--)
        {
            sectionEnd[i - 1] = Min(sectionEnd[i - 1], sectionEnd[i]);
        }
        long res = 0;
        for (int i = 0; i < sectionEnd.Length; i++)
        {
            res += sectionEnd[i] - i;
        }
        Console.WriteLine(res);
    }
}