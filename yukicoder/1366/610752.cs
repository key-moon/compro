// detail: https://yukicoder.me/submissions/610752
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
        bool isKadomatsu(int[] a)
        {
            return
                a.Distinct().Count() == 3 &&
                (a.Max() == a[1] || a.Min() == a[1]);
        }
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                (a[i], b[j]) = (b[j], a[i]);
                if (isKadomatsu(a) && isKadomatsu(b))
                {
                    Console.WriteLine("Yes");
                    return;
                }
                (a[i], b[j]) = (b[j], a[i]);
            }
        }
        Console.WriteLine("No");
    }
}