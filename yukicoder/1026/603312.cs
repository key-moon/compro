// detail: https://yukicoder.me/submissions/603312
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
        var back = new List<string>();
        var front = new List<string>();
        for (int i = 0; i < n; i++)
        {
            var ts = Console.ReadLine().Split();
            (ts[0] == "0" ? back : front).Add(ts[1]);
        }
        Console.WriteLine($"{string.Join("", front.Reverse<string>())}{string.Join("", back)}");
    }
}