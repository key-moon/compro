// detail: https://codeforces.com/contest/959/submission/36909572
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //偶数だったら初手で偶数引く、奇数だったらどうしようもない
        Console.WriteLine(n % 2 == 1 ? "Ehab" : "Mahmoud");
    }
}