// detail: https://atcoder.jp/contests/agc049/submissions/18100297
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool[][] mat = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine().Select(x => x == '1').ToArray()).ToArray();

        List<int>[] graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j]) graph[i].Add(j);
            }
        }
        
        int[] subCount = new int[n];
        for (int i = 0; i < n; i++)
        {
            bool[] arrived = new bool[n];
            Stack<int> st = new Stack<int>();
            st.Push(i);
            arrived[i] = true;
            subCount[i]++;
            while (st.Count != 0)
            {
                var elem = st.Pop();
                foreach (var adj in graph[elem])
                {
                    if (arrived[adj]) continue;
                    st.Push(adj);
                    arrived[adj] = true;
                    subCount[adj]++;
                }
            }
        }

        double res = 0;
        foreach (var item in subCount) res += 1.0 / item;
        Console.WriteLine(res);
    }
}
