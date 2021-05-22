// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0434/judge/5497605/C#
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
        var wdhc = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var W = wdhc[0];
        var D = wdhc[1];
        var H = wdhc[2];
        var C = wdhc[3];

        Func<int, int, long> genId = (int y, int x) => y * W + x;

        var res = W * D * 2 + H * W * 2 + H * D * 2;
        Dictionary<long, int> dic = new Dictionary<long, int>();

        var ops = Enumerable.Repeat(0, (int)C).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).GroupBy(x => genId(x[0], x[1])).ToArray();
        foreach (var op in ops)
        {
            var arr = op.ToArray();
            var x = arr[0][0];
            var y = arr[0][1];
            var z = arr.Sum(X => X[2]);
            var id = genId(y, x);
            if (dic.ContainsKey(id)) continue;
            dic[id] = z;
            res += z * 4;

            var u = 
                y == 0 ? H : 
                (dic.ContainsKey(genId(y - 1, x)) ? dic[genId(y - 1, x)] : 0L);
            var d =
                y == D - 1 ? H : 
                (dic.ContainsKey(genId(y + 1, x)) ? dic[genId(y + 1, x)] : 0L);
            var l = 
                x == 0 ? H : 
                (dic.ContainsKey(genId(y, x - 1)) ? dic[genId(y, x - 1)] : 0L);
            var r = 
                x == W - 1 ? H : 
                (dic.ContainsKey(genId(y, x + 1)) ? dic[genId(y, x + 1)] : 0L);

            res -= Min(u, z) * 2;
            res -= Min(d, z) * 2;
            res -= Min(l, z) * 2;
            res -= Min(r, z) * 2;
        }
        Console.WriteLine(res);
    }
}

