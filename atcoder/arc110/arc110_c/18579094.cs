// detail: https://atcoder.jp/contests/arc110/submissions/18579094
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
        var a = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        List<int> query = new List<int>();
        void Swap(int i)
        {
            (a[i - 1], a[i]) = (a[i], a[i - 1]);
            query.Add(i);
        }
        int next = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] == next)
            {
                for (int j = i; j > next; j--)
                {
                    Swap(j);
                }
                next = i;
            }
        }
        if (query.Distinct().Count() != n - 1 || !a.SequenceEqual(Enumerable.Range(0, n)))
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(string.Join("\n", query));
    }
}