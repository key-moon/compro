// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_2_C/judge/4774123/C#
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
        var a = Console.ReadLine().Split();

        var sorted = a.OrderBy(x => x[1]).ToArray();

        Console.WriteLine(string.Join(" ", sorted));
        Console.WriteLine("Stable");

        {
            for (int i = 0; i < n; i++)
            {
                var min = a.Skip(i).Min(x => x[1]);
                if (a[i][1] != min)
                {
                    var ind = i + a.Skip(i).TakeWhile(x => x[1] != min).Count();
                    var tmp = a[i];
                    a[i] = a[ind];
                    a[ind] = tmp;
                }
            }

            Console.WriteLine(string.Join(" ", a));
            Console.WriteLine(a.SequenceEqual(sorted) ? "Stable" : "Not stable");
        }
    }
}
