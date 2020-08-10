// detail: https://atcoder.jp/contests/agc047/submissions/15805173
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
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        Solve(4, 4);
        Solve(0, 0);
        Solve(1000000000, 0);
        Solve(0, 1000000000);
        Console.WriteLine(Solve(0, 0));
    }

    public static string Solve(ulong a, ulong b)
    {
        checked
        {
            List<string> seq = new List<string>();
            var xptr = 0;
            var yptr = 1;
            var resptr = 2;

            var zeroPtr = 99999;
            var onePtr = 3;

            ulong[] arr = new ulong[200000];
            arr[xptr] = (ulong)a;
            arr[yptr] = (ulong)b;

            void CompAssign(int i, int j, int k) { arr[k] = arr[i] < arr[j] ? 1UL : 0UL; seq.Add($"< {i} {j} {k}"); }
            void AddAssign(int i, int j, int k) { arr[k] = arr[i] + arr[j]; seq.Add($"+ {i} {j} {k}"); }

            void DoubleAssign(int numPtr, int destPtr) => AddAssign(numPtr, numPtr, destPtr);

            AddAssign(xptr, yptr, onePtr);
            CompAssign(resptr, onePtr, onePtr);

            //d     d+30   d+60
            //| data | bulk |
            void GenBytes(int numptr, int destptr)
            {
                AddAssign(numptr, onePtr, numptr);
                for (int t = destptr; t < destptr + 30; t++)
                {
                    var p = t + 1;
                    DoubleAssign(p, p + 1);
                    var q = p + 1;
                    AddAssign(q, onePtr, q);
                    for (int j = q; j < destptr + 31; j++)
                        DoubleAssign(j, j + 1);
                    CompAssign(destptr + 31, numptr, t);
                    DoubleAssign(p, p + 1);
                    AddAssign(q, t, q);
                }
            }

            var aBinOffset = 9;
            var bBinOffset = 50;
            GenBytes(0, aBinOffset);
            GenBytes(1, bBinOffset);

            void And(int aptr, int bptr, int destptr)
            {
                var tmpPtr = 5;
                AddAssign(aptr, bptr, tmpPtr);
                CompAssign(onePtr, tmpPtr, destptr);
            }

            for (int t = 0; t < 60; t++)
            {
                DoubleAssign(resptr, resptr);
                for (int s = 0; s < t; s++)
                {
                    if (t - 31 < s && s < 30)
                    {
                        //bitwise-and
                        And(aBinOffset + t - 1 - s, bBinOffset + s, 6);
                        AddAssign(resptr, 6, resptr);
                    }
                }
            }

            if (a * b != arr[resptr]) throw new Exception();

            return $"{seq.Count}\n{string.Join("\n", seq)}";
        }
    }
}
