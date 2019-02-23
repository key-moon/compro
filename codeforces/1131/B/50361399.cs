// detail: https://codeforces.com/contest/1131/submission/50361399
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

class Ph
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int a = 0;
        int b = 0;
        long res = 1;
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToList();
            var newa = ab[0];
            var newb = ab[1];
            //まず最初のドローまでたどり着くか
            if (a > b)
            {
                if (a <= newb)
                {
                    b = a;
                    res++;
                }
                else
                {
                    b = newb;
                    goto end;
                }

            }
            if (a < b)
            {
                if (b <= newa)
                {
                    a = b;
                    res++;
                }
                else
                {
                    a = newa;
                    goto end;
                }
            }
            //連れ添っていく
            if (a != b) throw new Exception();
            res += Min(newa, newb) - a;
            a = Min(newa, newb);
            b = Min(newa, newb);
            //終わり
            end:;
            a = newa;
            b = newb;
        }
        Console.WriteLine(res);
    }
}