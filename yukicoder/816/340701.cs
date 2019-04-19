// detail: https://yukicoder.me/submissions/340701
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
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        //a < bとする
        //a==bの場合 c==aが成立
        //a以下の場合
        var max = (int)Ceiling(Sqrt(a + b));
        long cand = -1;
        for (int i = 1; i <= max; i++)
        {
            if ((a + b) % i != 0) continue;

            var op = (a + b) / i;
            if (a != i && b != i && (a + i) % b == 0 && (b + i) % a == 0)
            {
                Console.WriteLine(i);
                return;
            }
            if (a != op && b != op && (a + op) % b == 0 && (b + op) % a == 0)
            {
                cand = op;
            }
        }
        Console.WriteLine(cand);
    }
}
