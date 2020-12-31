// detail: https://yukicoder.me/submissions/598665
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
        HashSet<int> hashset = new HashSet<int>();
        for (int i = 1; i <= n; i++) hashset.Add(n / i);
        Console.WriteLine(hashset.Count);
    }
}