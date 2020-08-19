// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_3_D/judge/4774920/C#
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
        string s = Console.ReadLine();
        Stack<Tuple<long, int>> ponds = new Stack<Tuple<long, int>>();
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '\\')
            {
                stack.Push(i);
            }
            if (s[i] == '/')
            {
                if (stack.Count == 0) continue;
                var start = stack.Pop();
                long size = i - start;
                while (ponds.Count != 0 && start < ponds.Peek().Item2)
                    size += ponds.Pop().Item1;
                ponds.Push(new Tuple<long, int>(size, start));
            }
        }

        Console.WriteLine(ponds.Sum(x => x.Item1));
        Console.WriteLine(string.Join(" ", new long[] { ponds.Count }.Concat(ponds.Select(x => x.Item1).Reverse())));
    }
}
