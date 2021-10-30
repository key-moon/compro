// detail: https://atcoder.jp/contests/abc225/submissions/26906598
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        LinkedListNode<int>[] nodes = Enumerable.Range(0, n).Select(x => new LinkedListNode<int>(x + 1)).ToArray();
        List<int> l = new List<int>(n);
        for (int i = 0; i < q; i++)
        {
            var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var t = query[0];
            if (t == 1)
            {
                var x = query[1] - 1;
                var y = query[2] - 1;
                LinkedListNode<int>.Connect(nodes[x], nodes[y]);
            }
            if (t == 2)
            {
                var x = query[1] - 1;
                var y = query[2] - 1;
                Trace.Assert(nodes[x].After == nodes[y]);
                Trace.Assert(nodes[y].Prev == nodes[x]);
                nodes[x].After = null; nodes[y].Prev = null;
            }
            if (t == 3)
            {
                l.Clear();
                var x = query[1] - 1;
                nodes[x].Head.FillList(l);
                Console.WriteLine($"{l.Count} {string.Join(" ", l)}");
            }
        }
    }
}

class LinkedListNode<T>
{
    public T Value;
    public LinkedListNode<T> Prev;
    public LinkedListNode<T> After;
    public LinkedListNode(T val) { Value = val; }

    public LinkedListNode<T> Head => Prev == null ? this : Prev.Head;

    public static void Connect(LinkedListNode<T> prev, LinkedListNode<T> after)
    {
        Trace.Assert(prev.After == null);
        Trace.Assert(after.Prev == null);
        prev.After = after;
        after.Prev = prev;
    }

    public void FillList(List<T> l)
    {
        l.Add(Value);
        if (After is null) return;
        After.FillList(l);
    }
}
