// detail: https://codeforces.com/contest/1153/submission/52709001
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static int[] parents;
    static int[] operations;
    static List<int>[] childlens;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //部分木に同じ問題を解かせ、マージは
        //maxであれば
        //一ノード極振りで上に張り付かせる
        //minであれば
        //全てを上に張り付かせる
        operations = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //operations = Enumerable.Repeat(0, n).ToArray();
        parents = Enumerable.Repeat(-1, 1).Concat(Console.ReadLine().Split().Select(x => int.Parse(x) - 1)).ToArray();
        //parents = Enumerable.Range(-1, n).ToArray();

        childlens = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 1; i < n; i++) childlens[parents[i]].Add(i);

        var leaves = childlens.Count(x => x.Count == 0);
        
        //自前でスタック退避とか実装します クソか?
        int[] res = new int[n];

        Stack<int> CallStack = new Stack<int>();
        Stack<int> CurrentFuncStates = new Stack<int>();
        CallStack.Push(0);
        CurrentFuncStates.Push(0);

        while (CallStack.Count > 0)
        {
            var node = CallStack.Pop();
            var state = CurrentFuncStates.Pop();
            if (childlens[node].Count == 0)
            {
                res[node] = 1;
            }
            //関数の返り値にあたるところです resがもう埋まっているので上に対して作用をさせます
            if (state == childlens[node].Count)
            {
                if (node == 0) continue;
                var parent = parents[node];
                var parentOperation = operations[parent];
                //max
                if (parentOperation == 1) res[parent] = Min(res[parent], res[node]);
                //min
                else res[parent] += res[node];
                continue;
            }
            if (state == 0)
            {
                res[node] = operations[node] == 1 ? int.MaxValue : 0;
            }
            state++;
            CallStack.Push(node);
            CurrentFuncStates.Push(state);
            CallStack.Push(childlens[node][state - 1]);
            CurrentFuncStates.Push(0);
        }
        Console.WriteLine(leaves - res[0] + 1);
    }
}

