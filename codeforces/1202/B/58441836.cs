// detail: https://codeforces.com/contest/1202/submission/58441836
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static int[][][] TakeSteps = Enumerable.Repeat(0, 10).Select(x => new int[10][]).ToArray();
    static P()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var res = Enumerable.Repeat(int.MaxValue, 10).ToArray();
                Queue<int> queue = new Queue<int>();
                res[i] = 0;
                res[j] = 0;
                queue.Enqueue(i);
                queue.Enqueue(j);
                while (queue.Count > 0)
                {
                    var elem = queue.Dequeue();
                    
                    if (res[(elem + i) % 10] == int.MaxValue)
                    {
                        res[(elem + i) % 10] = res[elem] + 1;
                        queue.Enqueue((elem + i) % 10);
                    }
                    if (res[(elem + j) % 10] == int.MaxValue)
                    {
                        res[(elem + j) % 10] = res[elem] + 1;
                        queue.Enqueue((elem + j) % 10);
                    }
                }
                TakeSteps[i][j] = res;
            }
        }
    }

    static void Main()
    {
        string s = Console.ReadLine();
        long[][] res = Enumerable.Repeat(0, 10).Select(x => new long[10]).ToArray();
        for (int i = 1; i < s.Length; i++)
        {
            var diff = (s[i] + 10 - s[i - 1]) % 10;
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    res[j][k] += TakeSteps[j][k][diff];
                }
            }
        }
        Console.WriteLine(string.Join("\n", res.Select(x => string.Join(" ", x.Select(y => int.MaxValue <= y ? -1 : y)))));
    }
}

