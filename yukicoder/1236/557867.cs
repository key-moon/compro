// detail: https://yukicoder.me/submissions/557867
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
        var ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = ab[0];
        var b = ab[1];
        var now = (a * 60 + b) * 60;
        int i = 0;
        while (true)
        {
            var sec = (int)Floor(i * 60.0 * 60 * 12 / 11);
            if (now <= sec)
            {
                Console.WriteLine(sec - now);
                return;
            }
            i++;
        }
    }
}
