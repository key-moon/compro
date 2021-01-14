// detail: https://yukicoder.me/submissions/603288
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
        var map = Enumerable.Repeat(0, n + 1).Select(_ => Enumerable.Repeat(1, n + 1).ToArray()).ToArray();
        var (y, x) = (0, 0);
        map[y][x] = 0;
        foreach (var c in Console.ReadLine())
        {
            if (c == 'R') x++;
            if (c == 'L') x--;
            if (c == 'U') y++;
            if (c == 'D') y--;
            try { map[y][x] = 0; } catch { }
        }

        Console.WriteLine(string.Join("\n", map.Reverse().Select(x => string.Join(" ", x))));
    }
}
