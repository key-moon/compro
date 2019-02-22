// detail: https://yukicoder.me/submissions/318947
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

class P
{
    static void Main()
    {
        int l = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        var w = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToList();
        int g = 0;
        for (int i = 0; i < n; i++)
        {
            g += w[i];
            if(g > l)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(n);
    }
}
