// detail: https://yukicoder.me/submissions/343679
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
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;


static class P
{
    static void Main()
    {
        string a = "";
        string b = "";
        foreach (var c in Console.ReadLine())
        {
            char ac, bc;
            if (c == '7')
            {
                ac = '6';
                bc = '1';
            }
            else
            {
                ac = c;
                bc = '0';
            }
            a += ac;
            b += bc;
        }
        a = a.TrimStart('0');
        b = b.TrimStart('0');
        Console.WriteLine($"{a} {b}");
    }
}