// detail: https://yukicoder.me/submissions/598619
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
        for (int i = 2; i <= 100; i++) n = n.ToString().Sum(x => x - '0');
        Console.WriteLine(n);
    }
}