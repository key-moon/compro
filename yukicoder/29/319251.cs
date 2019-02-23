// detail: https://yukicoder.me/submissions/319251
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Int = System.Int64;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> item = new List<int>(Enumerable.Repeat(0, 11));
        for (int i = 0; i < n; i++)
        {
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();
            item[a[0]]++;
            item[a[1]]++;
            item[a[2]]++;
        }
        int res = 0;
        int afs = item.Select(x => { res += x / 2; return x % 2; }).Sum() / 4;
        Console.WriteLine(afs + res);
    }
}
