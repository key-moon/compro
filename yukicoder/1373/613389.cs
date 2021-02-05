// detail: https://yukicoder.me/submissions/613389
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
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] res = new int[n - 1];
        int cnt = 1;
        foreach (var (elem, ind) in a.Select((elem, ind) => (elem, ind)).OrderBy(x => x.elem))
        {
            if (cnt < elem)
            {
                Console.WriteLine("NO");
                return;
            }
            res[ind] = cnt - elem;
            cnt++;
        }
        Console.WriteLine("YES");
        Console.WriteLine(string.Join("\n", res.Select(x => x + 1)));
    }
}