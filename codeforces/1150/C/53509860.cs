// detail: https://codeforces.com/contest/1150/submission/53509860
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
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var oneCount = a.Count(x => x == 1);
        var twoCount = a.Count(x => x == 2);
        if (oneCount == 0 || twoCount == 0)
        {
            Console.WriteLine(string.Join(" ", a));
            return;
        }
        else
        {
            List<int> res = new List<int>();
            res.Add(2);
            twoCount--;
            res.Add(1);
            oneCount--;
            res.AddRange(Enumerable.Repeat(2, twoCount));
            res.AddRange(Enumerable.Repeat(1, oneCount));
            Console.WriteLine(string.Join(" ", res));
            return;
        }
    }
}
