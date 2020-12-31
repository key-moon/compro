// detail: https://yukicoder.me/submissions/598679
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
        for (int i = 0; i < n; i++)
        {
            var abcd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine($"SELECT count(*) FROM point WHERE {abcd[0]}<=x and x<={abcd[1]} and {abcd[2]}<=y and y<={abcd[3]};");
        }
    }
}
