// detail: https://codeforces.com/contest/781/submission/87424246
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
        //同じfirstを持つものは全てsecondになるべき
        //残りは? secondで潰された彼らは仕方なくsecondを使う
        Tuple<int, Tuple<string, string>>[] b = new Tuple<int, Tuple<string, string>>[n];

        Tuple<List<int>, List<int>>[] a = Enumerable.Range(0, 26 * 26 * 26).Select(x => new Tuple<List<int>, List<int>>(new List<int>(), new List<int>())).ToArray();

        Tuple<string, string>[] cands = new Tuple<string, string>[n];
        Tuple<int, int>[] ids = new Tuple<int, int>[n];
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var name1 = input[0].Substring(0, 3);
            var name2 = input[0].Substring(0, 2) + input[1][0];
            cands[i] = new Tuple<string, string>(name1, name2);
            var id1 = Encode(name1);
            var id2 = Encode(name2);
            ids[i] = new Tuple<int, int>(id1, id2);
            a[id1].Item1.Add(i);
            a[id2].Item2.Add(i);
            b[i] = new Tuple<int, Tuple<string, string>>(i, new Tuple<string, string>(name1, name2));
        }

        bool[] used = new bool[26 * 26 * 26];
        string[] res = new string[n];

        Queue<int> queue = new Queue<int>();
        foreach (var item in a)
        {
            if (2 <= item.Item1.Count)
            {
                foreach (var i in item.Item1) queue.Enqueue(i);
            }
        }
        while (queue.Count != 0)
        {
            var elem = queue.Dequeue();
            if (res[elem] != null) continue;
            if (used[ids[elem].Item2]) goto nope;
            res[elem] = cands[elem].Item2;
            used[ids[elem].Item2] = true;
            foreach (var item in a[ids[elem].Item2].Item1)
            {
                queue.Enqueue(item);
            }
        }



        for (int i = 0; i < res.Length; i++)
            if (res[i] == null)
            {
                if (used[ids[i].Item1]) throw new Exception();
                res[i] = cands[i].Item1;
                used[ids[i].Item1] = true;
            }
        Console.WriteLine("YES");
        Console.WriteLine(string.Join("\n", res));
        return;
        nope:;
        Solve(b, n);
    }

    static void Solve(Tuple<int, Tuple<string, string>>[] a, int n)
    {
        HashSet<string> used = new HashSet<string>();
        string[] res = new string[n];
        foreach (var group in a.GroupBy(x => x.Item2.Item1).OrderByDescending(x => x.Count()))
        {
            var count = group.Count();
            if (count != 1)
            {
                foreach (var item in group)
                {
                    var name = item.Item2.Item2;
                    if (!used.Add(name))
                    {
                        goto nope;
                    }
                    res[item.Item1] = name;
                }
            }
            else
            {
                var item = group.First();
                var name1 = item.Item2.Item1;
                var name2 = item.Item2.Item2;
                if (!used.Add(name1))
                {
                    if (!used.Add(name2))
                    {
                        goto nope;
                    }
                    res[item.Item1] = name2;
                }
                else
                {
                    res[item.Item1] = name1;
                }
            }

        }
        Console.WriteLine("YES");
        Console.WriteLine(string.Join("\n", res));
        return;
        nope:;
        Console.WriteLine("NO");
    }

    static int Encode(string s)
    {
        return ((s[0] - 'A') * 26 + (s[1] - 'A')) * 26 + (s[2] - 'A');
    }
}