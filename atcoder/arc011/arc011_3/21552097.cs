// detail: https://atcoder.jp/contests/arc011/submissions/21552097
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
        var s = Console.ReadLine().Split();
        var fst = s[0];
        var lst = s[1];
        int n = int.Parse(Console.ReadLine());
        var words = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).Prepend(fst).Append(lst).ToArray();
        int[] prev = Enumerable.Repeat(-1, words.Length).ToArray();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        prev[0] = 0;
        while (queue.Count != 0)
        {
            var curInd = queue.Dequeue();
            for (int i = 0; i < n + 2; i++)
            {
                if (prev[i] != -1) continue;
                var diff = words[curInd].Zip(words[i]).Count(x => x.First != x.Second);
                if (1 < diff) continue;
                prev[i] = curInd;
                queue.Enqueue(i);
            }
        }
        if (prev[n + 1] == -1)
        {
            Console.WriteLine(-1);
            return;
        }
        List<string> res = new List<string>();
        int cur = n + 1;
        while (true)
        {
            res.Add(words[cur]);
            if (cur == prev[cur]) break;
            cur = prev[cur];
        }
        res.Reverse();
        Console.WriteLine(res.Count - 2);
        Console.WriteLine(string.Join("\n", res));
    }
}