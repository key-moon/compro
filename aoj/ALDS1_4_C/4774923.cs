// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_4_C/judge/4774923/C#
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
        HashSet<string> set = new HashSet<string>();
        for (int i = 0; i < n; i++)
        {
            var query = Console.ReadLine().Split();
            if (query[0] == "insert")
                set.Add(query[1]);
            else
                Console.WriteLine(set.Contains(query[1]) ? "yes" : "no");
        }
    }
}

