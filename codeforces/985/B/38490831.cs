// detail: https://codeforces.com/contest/985/submission/38490831
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        bool[][] j = Enumerable.Repeat(0, nm[0]).Select(_ => Console.ReadLine().Select(x => x == '1').ToArray()).ToArray();
        //スイッチnを押した時にランプmがオンになるか
        int[] count = new int[nm[1]];
        foreach (var item in j)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i]) count[i]++;
            }
        }

        foreach (var item in j)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] && count[i] == 1) goto end;
            }
            Console.WriteLine("YES");
            return;
            end:;
        }
        Console.WriteLine("NO");
    }
}