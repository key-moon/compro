// detail: https://atcoder.jp/contests/abc111/submissions/16278721
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
        var points = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select(x => (x[0], x[1])).ToArray();
        {
            var count = points.Count(x => (x.Item1 + x.Item2) % 2 == 0);
            if (count != 0 && count != n)
            {
                Console.WriteLine(-1);
                return;
            }
        }
        var parity = (points[0].Item1 + points[0].Item2) % 2;
        List<int> arms = new List<int>();
        for (int i = 30; i >= 0; i--)
            arms.Add(1 << i);
        if (parity == 0) arms.Add(1);
        Console.WriteLine(arms.Count);
        Console.WriteLine(string.Join(" ", arms));
        (int, int) getPos(string s)
        {
            int y = 0;
            int x = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'U':
                        y += arms[i];
                        break;
                    case 'D':
                        y -= arms[i];
                        break;
                    case 'R':
                        x += arms[i];
                        break;
                    case 'L':
                        x -= arms[i];
                        break;
                }
            }
            return (y, x);
        }
        foreach (var (x, y) in points)
        {
            long curY = y, curX = x;
            string res = "";
            foreach (var arm in arms)
            {
                var min = long.MaxValue;
                char minOp = '#';
                long minY = 0, minX = 0;
                void Update(long y, long x, char c)
                {
                    var diff = Abs(y) + Abs(x);
                    if (diff < min) { minOp = c; minY = y; minX = x; min = diff; }
                }
                Update(curY - arm, curX, 'U');
                Update(curY + arm, curX, 'D');
                Update(curY, curX - arm, 'R');
                Update(curY, curX + arm, 'L');
                (curY, curX) = (minY, minX);
                res += minOp;
            }
            var pos = getPos(res);
            if (res.Length != arms.Count || pos != (y, x)) throw new Exception();
            Console.WriteLine(res);
        }
    }
}
