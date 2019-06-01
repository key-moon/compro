// detail: https://codeforces.com/contest/1148/submission/54929704
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
    static int[] p;
    static int[] indexOf;
    static List<Tuple<int, int>> ops = new List<Tuple<int, int>>();
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        indexOf = new int[n + 1];
        for (int i = 0; i < p.Length; i++) indexOf[p[i]] = i;

        if (n == 2)
        {
            if (p[0] == 2)
            {
                Console.WriteLine("1");
                Console.WriteLine("1 2");
            }
            else
            {
                Console.WriteLine("0");
            }
            return;
        }

        //set 1
        if (indexOf[1] != 0)
        {
            if (IsFirstHalf(indexOf[1]))
            {
                Swap(indexOf[1], p.Length - 1);
                Swap(0, indexOf[1]);
            }
            else
            {
                Swap(0, indexOf[1]);
            }
        }


        for (int i = 1; i < p.Length / 2; i++)
        {
            var target = i + 1;
            if (indexOf[target] == i) continue;
            if (isValidMove(i, indexOf[target]))
            {
                Swap(i, indexOf[target]);
            }
            else if (IsFirstHalf(indexOf[target]))
            {
                Swap(indexOf[target], p.Length - 1);
                Swap(i, indexOf[target]);
            }
            else
            {
                Swap(0, indexOf[target]);
                Swap(0, p.Length - 1);
                Swap(0, indexOf[1]);
                Swap(i, indexOf[target]);
            }
        }
        for (int i = p.Length / 2; i < p.Length; i++)
        {
            var target = i + 1;
            if (indexOf[target] == i) continue;
            Swap(0, indexOf[target]);
            Swap(indexOf[target], i);
            Swap(0, indexOf[1]);
        }
        Debug.Assert(p.Select((x, y) => x - 1 == y).All(x => x));
        Console.WriteLine(ops.Count);
        Console.WriteLine(string.Join("\n", ops.Select(x => $"{x.Item1} {x.Item2}")));
    }

    static void Swap(int a, int b)
    {
        Debug.Assert(isValidMove(a, b));
        ops.Add(new Tuple<int, int>(a + 1, b + 1));
        var tmp = p[a];
        p[a] = p[b];
        p[b] = tmp;
        indexOf[p[a]] = a;
        indexOf[p[b]] = b;
    }

    static bool IsFirstHalf(int ind)
    {
        return ind * 2 < p.Length;
    }

    static bool isValidMove(int a, int b) => Abs(a - b) * 2 >= p.Length;
}
