// detail: https://atcoder.jp/contests/abc209/submissions/24138996
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
        var words = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        var dic = words.Select(x => x[..3]).Concat(words.Select(x => x[^3..])).Distinct().Select((elem, ind) => (elem, ind)).ToDictionary(x => x.elem, x => x.ind);

        int[] outCnt = new int[dic.Count];
        List<int>[] inGraph = Enumerable.Repeat(0, dic.Count).Select(_ => new List<int>()).ToArray();
        foreach (var word in words)
        {
            var head = dic[word[..3]];
            var tail = dic[word[^3..]];
            outCnt[head]++;
            inGraph[tail].Add(head);
        }

        // 自分の番でこの単語から始める時:
        // -1: 負け
        //  1: 勝ち
        int[] state = new int[dic.Count];

        void DFS(int item)
        {
            // Trace.Assert(outCnt[item] == 0);
            if (state[item] == 0) state[item] = -1;
            foreach (var prevItem in inGraph[item])
            {
                if (outCnt[prevItem] == 0) continue;
                outCnt[prevItem]--;
                if (state[item] == -1)
                {
                    state[prevItem] = 1;
                    outCnt[prevItem] = 0;
                    DFS(prevItem);
                    continue;
                }
                if (outCnt[prevItem] == 0) DFS(prevItem);
            }
        }
        for (int i = 0; i < dic.Count; i++)
        {
            if (outCnt[i] != 0) continue;
            DFS(i);
        }
        foreach (var word in words)
        {
            Console.WriteLine(state[dic[word[^3..]]] switch
            {
                -1 => "Takahashi",
                1 => "Aoki",
                _ => "Draw"
            });
        }
    }
}