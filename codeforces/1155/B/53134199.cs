// detail: https://codeforces.com/contest/1155/submission/53134199
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

        int eightCount = 0;
        int otherCount = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '8')
            {
                eightCount++;
            }
            else
            {
                otherCount++;
            }
            if (eightCount == ((n - 11) / 2) + 1)
            {
                if (otherCount <= (n - 11) / 2)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
                return;
            }
        }
        Console.WriteLine("NO");
    }
}
