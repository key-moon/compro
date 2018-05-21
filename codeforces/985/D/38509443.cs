// detail: https://codeforces.com/contest/985/submission/38509443
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        //砂パックとフェンスの高さ
        long[] nh = Console.ReadLine().Split().Select(long.Parse).ToArray();
        long n = nh[0];
        long h = nh[1];
        //ビーチ
        //1 2 3 4 5 6 7 8 9 10 11...
        //砂をnパック h_1
        //h1<H
        //山を作るんだけど
        //もしHを超えるならば、N+(H*(H-1))/2


        //◯
        //◯◯
        //◯◯◯
        //◯◯◯◯
        //◯◯◯◯◯
        //◯◯◯◯◯◯
        //◯◯◯◯◯◯◯
        //◯◯◯◯◯◯◯◯
        //h*(h+1)/2=n

        //　　◯
        //　◯◯◯
        //◯◯◯◯◯
        //◯◯◯◯◯◯
        //◯◯◯◯◯◯◯
        //◯◯◯◯◯◯◯◯
        //◯◯◯◯◯◯◯◯◯
        //◯◯◯◯◯◯◯◯◯◯
        //



        long res = 0;
        long remain = 0;
        long height = stepHeight(n);
        
        if (height > h)
        {
            long extra = stepCount(h - 1);
            height = piramidHeight(n + extra);
            remain = n - (piramidCount(height) - extra);
            res = (height * 2 - 1 - (h - 1)) + remain / height + (remain % height != 0 ? 1 : 0);
        }
        else
        {
            remain = n - stepCount(height);
            res = height + remain / height + (remain % height != 0 ? 1 : 0);
        }
        Console.WriteLine(res);
    }

    static long piramidHeight(long n)
    {
        long res = (long)Floor(Sqrt(n));
        while (piramidCount(res + 1) <= n) res++;
        while (piramidCount(res) > n) res--;
        return res;
    }
    static long piramidCount(long n) => n * n;
    static long stepHeight(long n)
    {
        long res = (long)Floor((Sqrt(8 * n + 1) - 1) / 2);
        while (stepCount(res + 1) <= n) res++;
        while (stepCount(res) > n) res--;
        return res;
    }
    static long stepCount(long h) => (h * (h + 1)) / 2;
}