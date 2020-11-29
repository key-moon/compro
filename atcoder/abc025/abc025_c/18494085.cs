// detail: https://atcoder.jp/contests/abc025/submissions/18494085
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
        Dictionary<string, long> points = new Dictionary<string, long>();
        var b = Enumerable.Repeat(0, 2).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var c = Enumerable.Repeat(0, 3).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        long Solve(string s, char turn)
        {
            if (points.ContainsKey(s)) return points[s];
            char nTurn = (char)('o' ^ 'x' ^ turn);
            if (s.Contains('.'))
            {
                IEnumerable<long> res = Enumerable.Empty<long>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != '.') continue;
                    var buf = s.ToArray();
                    buf[i] = turn;
                    var nStr = string.Join("", buf);
                    res = res.Append(Solve(nStr, nTurn));
                }
                if (turn == 'o') return points[s] = res.Max();
                else return points[s] = res.Min();
            }
            {
                long res = 0;
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 3; j++)
                        if (s[i * 3 + j] == s[(i + 1) * 3 + j])
                            res += b[i][j];
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 2; j++)
                        if (s[i * 3 + j] == s[i * 3 + j + 1])
                            res += c[i][j];
                return res;
            }
        }

        var total = b.SelectMany(x => x).Sum() + c.SelectMany(x => x).Sum();
        var aRes = Solve("..." + "..." + "...", 'o');
        var bRes = total - aRes;
        Console.WriteLine(aRes);
        Console.WriteLine(bRes);
    }
}