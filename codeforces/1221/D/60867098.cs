// detail: https://codeforces.com/contest/1221/submission/60867098
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
        int q = int.Parse(Console.ReadLine());
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < q; i++)
        {
            builder.AppendLine(Solve().ToString());
        }
        Console.Write(builder.ToString());
    }

    static long Solve()
    {
        int n = int.Parse(Console.ReadLine());

        Tuple<long, long>[] cost = new Tuple<long, long>[]
{
            new Tuple<long, long>(-1, 0),
            new Tuple<long, long>(-1, 0),
            new Tuple<long, long>(-1, 0)
};
        for (int i = 0; i < n; i++)
        {
            var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Tuple<long, long>[] newcost = new Tuple<long, long>[3];
            for (int j = 0; j < 3; j++)
            {
                newcost[j] = new Tuple<long, long>(ab[0] + j, cost.Where(x => x.Item1 != ab[0] + j).Min(x => x.Item2) + ab[1] * j);
            }
            cost = newcost;
        }
        return cost.Min(x => x.Item2);
    }
}
