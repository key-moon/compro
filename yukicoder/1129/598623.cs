// detail: https://yukicoder.me/submissions/598623
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
        var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var res = 0;
        if (abcd[0] != abcd[2]) res = abcd[0] > abcd[2] ? 1 : -1;
        else if (abcd[1] != abcd[3]) res = (abcd[1] - abcd[3] + 3) % 3 == 2 ? 1 : -1;
        if (res == 1) Console.WriteLine("null");
        else if (res == -1) Console.WriteLine("tRue");
        else Console.WriteLine("Draw");
    }
}