// detail: https://yukicoder.me/submissions/319255
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
        int mark = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var a = Console.ReadLine().Split().Select(int.Parse).ToList();
            if ((a[0] ^ mark) * (a[1] ^ mark) == 0) mark ^= a[0] ^ a[1];
        }
        Console.WriteLine(mark);
    }
}
