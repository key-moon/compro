// detail: https://atcoder.jp/contests/arc108/submissions/18283345
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
        LinkedList<char> list = new LinkedList<char>("##" + Console.ReadLine() + "##");
        var cur = list.First.Next.Next;
        while (!(cur.Next.Next is null))
        {
            var nxt = cur.Next;
            var nnxt = nxt.Next;
            if (cur.Value == 'f' && nxt?.Value == 'o' && nnxt?.Value == 'x')
            {
                var prev = cur.Previous;
                list.Remove(cur);
                list.Remove(nxt);
                list.Remove(nnxt);
                cur = prev.Previous;
            }
            else
            {
                cur = nxt;
            }
        }
        Console.WriteLine(list.Count - 4);
    }
}