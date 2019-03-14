// detail: https://yukicoder.me/submissions/322502
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nmpq = Console.ReadLine().Split().Select(int.Parse).ToList();
        int cnt = 0;
        for (int i = 1; nmpq[0] > 0; i = i % 12 + 1)
        {
            cnt++;
            if (nmpq[2] <= i && i - nmpq[2] < nmpq[3]) nmpq[0] -= nmpq[1];
            nmpq[0] -= nmpq[1];
        }
        Console.WriteLine(cnt);
    }
}
