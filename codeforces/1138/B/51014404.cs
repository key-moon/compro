// detail: https://codeforces.com/contest/1138/submission/51014404
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //どちらに属しているアーティストも同人数ということは、演技できない人は同人数
        //演技できる人/できない人をどう割り振るかの問題になりますね
        var v = Console.ReadLine().Zip(Console.ReadLine(), (x, y) => (x == '1' ? 2 : 0) + (y == '1' ? 1 : 0)).ToArray();
        int no = 0;
        int all = 0;
        int cana = 0;
        int canc = 0;

        foreach (var p in v)
        {
            switch (p)
            {
                case 0:
                    no++;
                    break;
                case 1:
                    cana++;
                    break;
                case 2:
                    canc++;
                    break;
                default:
                    all++;
                    break;
            }
        }
        int value = all + cana;
        //最初cが持っているところから奪っていく
        //今奪ったもので「双方の個数の差」が何個かわったか これが0になれば勝ちっぽい?
        //1/1を奪うと当然2増える 0/1を奪うと1増える 0を奪うと増えない
        //n/2個奪ったら終わり
        //奪えるのはコスト2、コスト1、0
        for (int i = 0; i <= all; i++)
        {
            for (int j = 0; j <= cana + canc; j++)
            {
                if (i + j > n / 2) break;
                int k = n / 2 - (i + j);
                if (k > no) continue;
                if (i * 2 + j == value)
                {
                    List<int> res = new List<int>();
                    int ind = 1;
                    foreach (var p in v)
                    {
                        if(i != 0 && p == 3)
                        {
                            res.Add(ind);
                            i--;
                        }
                        if (j != 0 && (p == 2 || p == 1))
                        {
                            res.Add(ind);
                            j--;
                        }
                        if (k != 0 && p == 0)
                        {
                            res.Add(ind);
                            k--;
                        }
                        ind++;
                    }
                    Console.WriteLine(string.Join(" ",res));
                    return;
                }
            }
        }
        Console.WriteLine(-1);
        return;
    }
}
