// detail: https://yukicoder.me/submissions/598667
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

        Console.WriteLine(n % 400 == 0 || (n % 100 != 0 && n % 4 == 0) ? "Yes" : "No");
    }
}