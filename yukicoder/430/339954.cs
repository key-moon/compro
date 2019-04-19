// detail: https://yukicoder.me/submissions/339954
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string s = Console.ReadLine();
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 1; j <= 10 && i + j <= s.Length; j++)
            {
                var key = s.Substring(i, j);
                if (!dict.ContainsKey(key)) dict.Add(key, 0);
                dict[s.Substring(i, j)]++;
            }
        }
        int m = int.Parse(Console.ReadLine());
        long res = 0;
        for (int i = 0; i < m; i++)
        {
            var key = Console.ReadLine();
            if (!dict.ContainsKey(key)) continue;
            res += dict[key];
        }
        Console.WriteLine(res);
    }
}
