// detail: https://yukicoder.me/submissions/339749
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
        string s = Console.ReadLine();
        double safeCount = s.Count(x => x == 'o');
        for (int i = 0; i < s.Length; i++)
        {
            Console.WriteLine(safeCount * 100 / (s.Length - i));
            if (s[i] == 'o') safeCount--;
        }
    }
}