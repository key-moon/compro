// detail: https://codeforces.com/contest/1155/submission/53127609
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        char MaxChar = (char)('a' - 1);
        int index = -1;
        for (int i = 0; i < s.Length; i++)
        {
            if (MaxChar < s[i])
            {
                MaxChar = s[i];
                index = i;
            }
            if (MaxChar > s[i])
            {
                Console.WriteLine("YES");
                Console.WriteLine($"{index + 1} {i + 1}");
                return;
            }
        }
        Console.WriteLine("NO");
    }
}
