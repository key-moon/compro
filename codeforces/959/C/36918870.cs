// detail: https://codeforces.com/contest/959/submission/36918870
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        //n頂点の無向木の、頂点による辺問題を考える。
        int n = int.Parse(Console.ReadLine());
        //頂点1から深さ偶奇で辿っていき、偶数頂点と奇数頂点のうち小さい方が被覆
        if (n <= 5)
        {
            Console.WriteLine(-1);
        }
        else
        {
            for (int i = 2; i <= n / 2 + 1; i++)
            {
                Console.WriteLine($"1 {i}");
            }
            for (int i = n / 2 + 2; i <= n; i++)
            {
                Console.WriteLine($"2 {i}");
            }
        }
        
        //一直線は正解
        for (int i = 1; i < n; i++)
        {
            Console.WriteLine($"{i} {i + 1}");
        }
    }
}