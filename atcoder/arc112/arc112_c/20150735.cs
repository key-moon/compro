// detail: https://atcoder.jp/contests/arc112/submissions/20150735
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
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int>[] childs = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 1; i < n; i++)
            childs[p[i - 1] - 1].Add(i);

        Result[] results = new Result[n];
        for (int i = n - 1; i >= 0; i--)
        {
            var childReses = childs[i].Select(x => results[x]).OrderBy(x =>
            {
                if (x.NxtTurn == 0 && x.MyEarn >= x.OpponentEarn) return int.MaxValue;
                if (x.NxtTurn == 1) return x.MyEarn - x.OpponentEarn;
                return int.MinValue;
            });
            var result = new Result();
            result.MyEarn += 1;
            result.NxtTurn ^= 1;
            foreach (var childRes in childReses)
            {
                result.NxtTurn ^= 1;
                if (result.NxtTurn == 0)
                {
                    result.MyEarn += childRes.MyEarn;
                    result.OpponentEarn += childRes.OpponentEarn;
                }
                else
                {
                    result.OpponentEarn += childRes.MyEarn;
                    result.MyEarn += childRes.OpponentEarn;
                }
                result.NxtTurn ^= 1;
                result.NxtTurn ^= childRes.NxtTurn;
            }
            results[i] = result;
        }
        Console.WriteLine(results[0].MyEarn);
    }
}

class Result
{
    public int MyEarn;
    public int OpponentEarn;
    public int NxtTurn;
}
