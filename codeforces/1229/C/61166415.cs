// detail: https://codeforces.com/contest/1229/submission/61166415
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        List<int>[] bragTo = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        int[] bragFromCount = new int[n];
        List<int>[] bragFrom = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < m; i++)
        {
            var ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            var a = ab.Min();
            var b = ab.Max();
            bragTo[a].Add(b);
            bragFromCount[b]++;
            bragFrom[b].Add(a);
        }
        long currentRes = 0;
        for (int i = 0; i < n; i++)
        {
            foreach (var item in bragFrom[i])
            {
                currentRes += bragFrom[item].Count;
            }
        }
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(currentRes.ToString());

        int q = int.Parse(Console.ReadLine());
        //2つ前から来るやつ→自分に自慢してたやつに自慢してた個数
        //自分に自慢してたやつが根→自分が自慢してる個数

        //自分が根→
        for (int i = 0; i < q; i++)
        {
            int query = int.Parse(Console.ReadLine()) - 1;
            //bragger->query->?
            currentRes -= (long)bragFromCount[query] * bragTo[query].Count;
            foreach (var bragger in bragTo[query])
            {
                //?->bragger->query
                currentRes -= bragTo[bragger].Count;
                bragFromCount[bragger]--;
                bragTo[bragger].Add(query);
                bragFromCount[query]++;
                //query->bragger->?
                currentRes += bragFromCount[bragger];
            }
            bragTo[query].Clear();
            builder.AppendLine(currentRes.ToString());
        }
        Console.Write(builder.ToString());
    }
}
