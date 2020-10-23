// detail: https://yukicoder.me/submissions/570373
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
public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(long.Parse).OrderBy(x => x).ToArray();
        Dictionary<long, long> ways = new Dictionary<long, long>();
        long res = 0;
        foreach (var item in a)
        {
            //次の数字の作り方
            if (!ways.ContainsKey(item)) ways[item] = 0;
            if (ways.ContainsKey(item - 1))
            {
                ways[item + 1] = ways[item - 1];
                res += ways[item - 1];
            }
            ways[item]++;
            res++;
        }
        Console.WriteLine(res);
    }
}