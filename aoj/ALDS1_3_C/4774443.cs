// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/ALDS1_3_C/judge/4774443/C#
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
        LinkedList<int> list = new LinkedList<int>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var query = Console.ReadLine().Split();
            if (query[0] == "insert")
            {
                list.AddFirst(int.Parse(query[1]));
            }
            else if (query[0] == "delete")
            {
                list.Remove(int.Parse(query[1]));
            }
            else if (query[0] == "deleteFirst")
            {
                list.RemoveFirst();
            }
            else if (query[0] == "deleteLast")
            {
                list.RemoveLast();
            }
        }

        Console.WriteLine(string.Join(" ", list));
    }
}
