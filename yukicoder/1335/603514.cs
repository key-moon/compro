// detail: https://yukicoder.me/submissions/603514
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
        var a = Console.ReadLine();
        var s = Console.ReadLine();
        for (int i = 0; i < a.Length; i++)
        {
            s = s.Replace(i.ToString()[0], a[i]);
        }
        Console.WriteLine(s);
    }
}