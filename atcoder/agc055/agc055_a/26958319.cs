// detail: https://atcoder.jp/contests/agc055/submissions/26958319
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
#if DEBUG
        while (true)
        {
            Solve(Generate(n));
        }
#endif
        var s = Console.ReadLine();

        Console.WriteLine(string.Join("", Solve(s)));  
    }
    static int[] Solve(string s)
    {
        var cnts = new int[3][] { new int[3], new int[3], new int[3] };
        var vals = new Stack<int>[3][]
        {
            new Stack<int>[3] { new Stack<int>(), new Stack<int>(), new Stack<int>() },
            new Stack<int>[3] { new Stack<int>(), new Stack<int>(), new Stack<int>() },
            new Stack<int>[3] { new Stack<int>(), new Stack<int>(), new Stack<int>() }
        };
        var n = s.Length / 3;
        for (int i = 0; i < s.Length; i++)
        {
            cnts[i / n][s[i] - 'A']++;
            vals[i / n][s[i] - 'A'].Push(i);
        }

        string[] keys = new[] { "ABC", "ACB", "CAB", "BAC", "BCA", "CBA" };
        bool Consume(int[][] table, Dictionary<string, int> dic, string pattern, int amount)
        {
            dic[pattern] = amount;
            bool res = true;
            for (int i = 0; i < pattern.Length; i++)
            {
                table[i][pattern[i] - 'A'] -= amount;
                res &= 0 <= table[i][pattern[i] - 'A'];
            }
            return res;
        }

        for (int a = 0; a <= cnts[0][0]; a++)
        {
            var dic = keys.ToDictionary(x => x, y => 0);

            var b = cnts[0][0] - a;
            var copied = cnts.Select(x => x.ToArray()).ToArray();

            bool res = true;
            res &= Consume(copied, dic, "ABC", a);
            res &= Consume(copied, dic, "ACB", b);

            res &= Consume(copied, dic, "CAB", copied[2][1]);
            res &= Consume(copied, dic, "BAC", copied[2][2]);

            res &= Consume(copied, dic, "BCA", copied[0][1]);
            res &= Consume(copied, dic, "CBA", copied[0][2]);

            if (!res) continue;
            Trace.Assert(copied.All(x => x.All(x => x == 0)));

            int[] arr = new int[s.Length];
            foreach (var (key, ind) in keys.Select((elem, ind) => (elem, ind + 1)))
            {
                var amount = dic[key];
                for (int i = 0; i < key.Length; i++)
                {
                    for (int cnt = 0; cnt < amount; cnt++)
                    {
                        arr[vals[i][key[i] - 'A'].Pop()] = ind;
                    }
                }
            }
            Trace.Assert(arr.All(x => x != 0));
            return arr;
        }
        Trace.Assert(false);
        return null;
    }
    static Random rng = new Random(1337);
    static string Generate(int n)
    {
        var arr = Enumerable.Repeat('A', n).Concat(Enumerable.Repeat('B', n)).Concat(Enumerable.Repeat('C', n)).ToArray();
        return string.Join("", arr.OrderBy(x => rng.Next()));
    }
}