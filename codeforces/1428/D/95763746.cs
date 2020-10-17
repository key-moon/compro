// detail: https://codeforces.com/contest/1428/submission/95763746
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
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //1→その行の右にはなにもない
        //2→続いて
        //3→次のときに新しい行開始
        List<(int, int)> res = new List<(int, int)>();

        int h = 0;
        Stack<int> two = new Stack<int>();
        bool lastIs3 = false;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == 0) continue;
            if (lastIs3)
            {
                if (a[i] == 1 && two.Count != 0) { }
                else
                {
                    res.Add((h, i));
                    h++;
                    lastIs3 = false;
                }
            }
            if (a[i] == 3)
            {
                res.Add((h, i));
                lastIs3 = true;
            }
            if (a[i] == 2)
            {
                res.Add((h, i));
                two.Push(h);
                h++;
            }
            if (a[i] == 1)
            {
                if (two.Count != 0)
                {
                    var tmph = two.Pop();
                    res.Add((tmph, i));
                }
                else
                {
                    res.Add((h, i));
                    h++;
                }
            }
        }

        if (lastIs3 || two.Count != 0 || (res.Count != 0 && n <= res.Max(x => x.Item1)))
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(res.Count);
        foreach (var (y, x) in res)
        {
            Console.WriteLine($"{y + 1} {x + 1}");
        }
    }
}