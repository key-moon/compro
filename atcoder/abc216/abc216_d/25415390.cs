// detail: https://atcoder.jp/contests/abc216/submissions/25415390
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
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        Dictionary<int, int> dic = new Dictionary<int, int>();
        Stack<int>[] stacks = new Stack<int>[m];
        void PopNext(int ind)
        {
            while (stacks[ind].Count != 0)
            {
                var nxt = stacks[ind].Pop();
                if (dic.ContainsKey(nxt))
                {
                    var another = dic[nxt];
                    dic.Remove(nxt);
                    PopNext(another);
                    continue;
                }
                dic[nxt] = ind;
                break;
            }
        }
        for (int i = 0; i < m; i++)
        {
            int.Parse(Console.ReadLine());
            stacks[i] = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            PopNext(i);
        }

        Console.WriteLine(dic.Count == 0 ? "Yes" : "No");
    }
}