// detail: https://codeforces.com/contest/1292/submission/69101535
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nq[0];
        var q = nq[1];
        int unpassable = 0;
        var u = new bool[n + 2];
        var d = new bool[n + 2];
        for (int i = 0; i < q; i++)
        {
            var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var r = rc[0];
            var c = rc[1];
            var curArr = (r == 1 ? u : d);
            var oppArr = (r != 1 ? u : d);
            var firstState = curArr[c];
            curArr[c] ^= true;
            if (firstState)
            {
                if (oppArr[c - 1]) unpassable--;
                if (oppArr[c]) unpassable--;
                if (oppArr[c + 1]) unpassable--;
            }
            else
            {
                if (oppArr[c - 1]) unpassable++;
                if (oppArr[c]) unpassable++;
                if (oppArr[c + 1]) unpassable++;
            }

            Console.WriteLine(unpassable == 0 ? "Yes" : "No");
        }
    }
}