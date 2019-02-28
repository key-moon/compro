// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_15_A/judge/3403315/C#
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using System.Collections;

class P
{
    static void Main()
    {
        var a = int.Parse(Console.ReadLine());
        int res = 0;
        while(a>=25){
            res++;
            a-=25;
        }
        while(a>=10){
            res++;
            a-=10;
        }
        while(a>=5){
            res++;
            a-=5;
        }
        while(a>=1){
            res++;
            a-=1;
        }
        Console.WriteLine(res);
    }
}
