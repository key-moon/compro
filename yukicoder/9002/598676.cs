// detail: https://yukicoder.me/submissions/598676
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
        var n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            string s = "";
            if (i % 3 == 0) s += "Fizz";
            if (i % 5 == 0) s += "Buzz";
            if (s.Length == 0) s = i.ToString();
            Console.WriteLine(s);
        }
    }
}
