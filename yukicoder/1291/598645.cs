// detail: https://yukicoder.me/submissions/598645
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
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(a == 1 ? "10" : '9' + string.Join("", Enumerable.Repeat('0', a - 1)));
        }
    }
}
