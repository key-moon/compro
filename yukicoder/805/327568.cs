// detail: https://yukicoder.me/submissions/327568
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        long res = 0;
        for (int i = 1; i < n - 1; i++)
        {
            if (s[i] != 'M') continue;
            var max = Min(i, n - i - 1);
            for (int j = 1; j <= max; j++)
            {
                if (s[i - j] == 'U' && s[i + j] == 'G') res++;
            }
        }
        Console.WriteLine(res);
    }
}
