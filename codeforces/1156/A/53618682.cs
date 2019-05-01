// detail: https://codeforces.com/contest/1156/submission/53618682
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int res = 0;
        bool top = false;
        for (int i = 1; i < a.Length; i++)
        {
            var x = Min(a[i - 1], a[i]);
            var y = Max(a[i - 1], a[i]);
            if (x == 2 && y == 3) goto Infinite;
            if (x == 1 && y == 2) res += top ? 2 : 3;
            if (x == 1 && y == 3) res += 4;
            top = a[i - 1] == 3 && a[i] == 1;
        }
        Console.WriteLine("Finite");
        Console.WriteLine(res);
        return;
    Infinite:;
        Console.WriteLine("Infinite");

    }
}
