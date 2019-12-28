// detail: https://codeforces.com/contest/1283/submission/67812512
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var m = nm[1];
        var trees = Console.ReadLine().Split().Select(int.Parse).ToArray();
        HashSet<int> occupied = new HashSet<int>(trees);
        var left = trees.Select(x => x - 1).ToList();
        var right = trees.Select(x => x + 1).ToList();
        int dist = 1;
        long res = 0;
        while (true)
        {
            List<int> newLeft = new List<int>();
            foreach (var item in left)
            {
                if (!occupied.Add(item)) continue;
                newLeft.Add(item - 1);
                res += dist;
                m--;
                if (0 >= m) goto end;
            }
            left = newLeft;
            List<int> newRight = new List<int>();
            foreach (var item in right)
            {
                if (!occupied.Add(item)) continue;
                res += dist;
                newRight.Add(item + 1);
                m--;
                if (0 >= m) goto end;
            }
            right = newRight;
            dist++;
        }
        end:;
        Console.WriteLine(res);
        Console.WriteLine(string.Join(" ", occupied.Except(trees)));
    }
}
