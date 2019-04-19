// detail: https://yukicoder.me/submissions/339945
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
        int n = int.Parse(Console.ReadLine());
        int[][] res = Enumerable.Repeat(0, n).Select(_ => new int[n]).ToArray();
        int num = 1;
        for (int offset = 0, count = n - 1; count >= 0; count -= 2, offset++)
        {
            int y = offset;
            int x = offset;
            for (int i = 0; i < count; i++) res[y][x++] = num++;
            for (int i = 0; i < count; i++) res[y++][x] = num++;
            for (int i = 0; i < count; i++) res[y][x--] = num++;
            for (int i = 0; i < count; i++) res[y--][x] = num++;
        }
        if (n % 2 == 1) res[n / 2][n / 2] = num;
        Console.WriteLine(string.Join("\n", res.Select(x => string.Join(" ", x.Select(y => y.ToString().PadLeft(3, '0'))))));
    }
}
