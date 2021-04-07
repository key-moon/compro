// detail: https://atcoder.jp/contests/arc105/submissions/21552457
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
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
    }
    static void Solve()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        // 置き終わった時にxor=0だったら勝ち
        //
        // 奇数の時: 後手が絶対に勝てる
        //          先手番で終わる
        //          後手は今一番大きいところに一番大きいものを追加すると、置き終わった時点でxor!=0とできる
        //
        // 偶数の時: pairにできる時のみ後手勝ち、そうでない限り先手
        //          後手番で終わる
        if (n % 2 == 1)
        {
            Console.WriteLine("Second");
            return;
        }
        else
        {
            if (a.GroupBy(x => x).All(x => x.Count() % 2 == 0))
            {
                Console.WriteLine("Second");
            }
            else
            {
                Console.WriteLine("First");
            }
        }
    }
}
