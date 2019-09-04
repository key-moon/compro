// detail: https://codeforces.com/contest/1214/submission/60005045
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        bool[][] map = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Select(x => x == '.').ToArray()).ToArray();
        var res = 2;
        for (int i = n + m - 3; i >= 1; i--)
        {
            var y = Min(i, n - 1);
            var x = i - y;
            while (0 <= y && x < m)
            {
                map[y][x] &= ((x == m - 1 ? false : map[y][x + 1]) | (y == n - 1 ? false : map[y + 1][x]));
                y--;
                x++;
            }
        }
        for (int i = 1; i < n + m - 2; i++)
        {
            var y = Min(i, n - 1);
            var x = i - y;
            int count = 0;
            while (0 <= y && x < m)
            {
                map[y][x] &= ((x == 0 ? false : map[y][x - 1]) | (y == 0 ? false : map[y - 1][x]));
                if (map[y][x]) count++;
                y--;
                x++;
            }
            res = Min(count, res);
        }
        Console.WriteLine(res);
    }
}
