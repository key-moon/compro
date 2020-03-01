// detail: https://atcoder.jp/contests/abc157/submissions/10433540
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var bingo = Enumerable.Repeat(0, 3).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int a = int.Parse(Console.ReadLine());
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (bingo[j][k] == a) bingo[j][k] = -1;
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (Enumerable.Range(0, 3).All(j => bingo[i][j] == -1) ||
                Enumerable.Range(0, 3).All(j => bingo[j][i] == -1))
            {
                Console.WriteLine("Yes");
                return;
            }
        }
        if (Enumerable.Range(0, 3).All(j => bingo[j][j] == -1) ||
            Enumerable.Range(0, 3).All(j => bingo[j][2 - j] == -1))
        {
            Console.WriteLine("Yes");
            return;
        }
        Console.WriteLine("No");
    }
}
