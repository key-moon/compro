// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1179/judge/4728129/C#
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
        Dictionary<int, int> date = new Dictionary<int, int>();
        int ind = 0;

        for (int y = 1; y < 1000; y++)
        {
            var isLeap = y % 3 == 0;
            for (int m = 1; m <= 10; m++)
            {
                var max = isLeap || m % 2 == 1 ? 20 : 19;
                for (int d = 1; d <= max; d++)
                {
                    date.Add(Encode(y, m, d), ind++);
                }
            }
        }


        for (int i = 0; i < t; i++)
        {
            var ymd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var y = ymd[0];
            var m = ymd[1];
            var d = ymd[2];
            Console.WriteLine(ind - date[Encode(y, m, d)]);
        }
    }
    static int Encode(int y, int m, int d) => (y * 11 + m) * 21 + d;
}
