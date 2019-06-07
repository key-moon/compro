// detail: https://codeforces.com/contest/1172/submission/55260655
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).ToArray();

        if (b.Distinct().Count() == 1 && b[0] == 0)
        {
            Console.WriteLine(n);
            return;
        }
        if (b.Contains(1))
        {
            var oneIndex = b.ToList().IndexOf(1);
            for (int i = oneIndex; i < b.Length; i++)
            {
                if (b[i] != i - oneIndex + 1) goto end;
            }
            for (int i = oneIndex - 1, card = n; i >= 0; i--, card--)
            {
                if (b[i] != 0 && b[i] <= card) goto end;
            }
            Console.WriteLine(oneIndex);
            return;
        }
    end:;
        Console.WriteLine(b.Select((item, index) => item == 0 ? 0 : Max(0, index - item + 2)).Max() + n);
    }
}