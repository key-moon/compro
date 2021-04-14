// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1129/judge/5374478/C#
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
        while (true)
        {
            var nr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = nr[0];
            var r = nr[1];
            if (n == 0) break;
            var deck = Enumerable.Range(1, n).Reverse().ToArray();
            for (int i = 0; i < r; i++)
            {
                var pc = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var p = pc[0];
                var c = pc[1];
                deck = 
                    deck.Skip(p - 1).Take(c)
                    .Concat(deck.Take(p - 1))
                    .Concat(deck.Skip(p + c - 1))
                    .ToArray();
            }
            Console.WriteLine(deck.First());
        }
    }
}
