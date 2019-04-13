// detail: https://codeforces.com/contest/1153/submission/52688694
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
    static void Main()
    {
        var mnh = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < mnh[0]; i++)
        {
            var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var res = new int[mnh[1]];
            for (int j = 0; j < mnh[1]; j++)
            {
                if (line[j] == 1) res[j] = Min(a[j], b[i]);
            }
            builder.AppendLine(string.Join(" ", res));
        }
        Console.WriteLine(builder.ToString());
    }
}

