// detail: https://codeforces.com/contest/1152/submission/53235538
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
using Debug = System.Diagnostics.Debug;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using System.Runtime.CompilerServices;

static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var res = Solve(n);
        //for (int i = 1; i < 1000000; i++) Solve(i);
        Console.WriteLine(res.Item1);
        Console.WriteLine(string.Join(" ", res.Item2));
    }

    static Tuple<int,List<int>> Solve(int n)
    {
        List<int> ops = new List<int>();
        var opCount = 0;
        while (true)
        {
            //Debug.WriteLine(Convert.ToString(n, 2).PadLeft(20));
            if (PopCount(n + 1) == 1 || n == 0) break;
            int msb = -1;
            for (int i = 28; i >= 0; i--)
            {
                if ((n & (1 << i)) != 0)
                {
                    msb = i;
                    break;
                }
            }
            ops.Add(msb + 1);
            n ^= (1 << msb + 1) - 1;
            opCount++;
            //Debug.WriteLine(Convert.ToString(n, 2).PadLeft(20));
            if (PopCount(n + 1) == 1 || n == 0) break;
            n++;
            opCount++;
        }
        if (opCount > 40) throw new Exception();
        return new Tuple<int, List<int>>(opCount, ops);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte PopCount(int n)
    {
        unchecked
        {
            int msb = 0;
            if (n < 0)
            {
                n = -(n + 1);
                msb = 1;
            }
            n = (n & 0x55555555) + ((n >> 1) & 0x55555555);
            n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
            n = (n & 0x0f0f0f0f) + ((n >> 4) & 0x0f0f0f0f);
            n = (n & 0x00ff00ff) + ((n >> 8) & 0x00ff00ff);
            return (byte)((n & 0x0000ffff) + ((n >> 16) & 0x0000ffff) + msb);
        }
    }
}
