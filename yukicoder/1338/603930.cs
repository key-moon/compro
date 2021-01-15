// detail: https://yukicoder.me/submissions/603930
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
        var hwq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var h = hwq[0];
        var w = hwq[1];
        var q = hwq[2];
        long res = (long)h * w;
        Dictionary<int, int> minPos = new Dictionary<int, int>();
        for (int i = 0; i < q; i++)
        {
            var yx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var y = yx[0] - 1;
            var x = yx[1] - 1;
            if (!minPos.ContainsKey(x)) minPos[x] = h;
            if (y < minPos[x])
            {
                res -= minPos[x] - y;
                minPos[x] = y;
            }
            Console.WriteLine(res);
        }
    }
}