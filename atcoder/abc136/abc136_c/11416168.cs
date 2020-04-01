// detail: https://atcoder.jp/contests/abc136/submissions/11416168
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


public static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var h = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int last = -100;
        for (int i = 0; i < h.Length; i++)
        {
            var item = h[i];
            if (last > item)
            {
                item++;
            }
            if (last > item)
            {
                Console.WriteLine("No");
                return;
            }
            last = item;
        }
        Console.WriteLine("Yes");
    }
}
