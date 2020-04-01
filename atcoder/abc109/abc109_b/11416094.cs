// detail: https://atcoder.jp/contests/abc109/submissions/11416094
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
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;


public static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        HashSet<string> words = new HashSet<string>();
        char lastChar = '*';
        for (int i = 0; i < n; i++)
        {
            var s = Console.ReadLine();
            if ((lastChar != '*' && lastChar != s.First()) || !words.Add(s))
            {
                Console.WriteLine("No");
                return;
            }
            lastChar = s.Last();
        }
        Console.WriteLine("Yes");
    }
}
