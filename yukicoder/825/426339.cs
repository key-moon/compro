// detail: https://yukicoder.me/submissions/426339
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
        var abc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = abc[0];
        var b = abc[1];
        var c = abc[2];
        for (int price = 1; price <= a + b * 10; price++)
        {
            for (int aCount = 0; aCount <= a; aCount++)
            {
                for (int bCount = 0; bCount <= b; bCount++)
                {
                    var pay = aCount + bCount * 10;
                    if (pay < price) continue;
                    var diff = pay - price;
                    var backCount = diff / 10 + diff % 10;
                    if ((a - aCount) + (b - bCount) + backCount == c)
                    {
                        Console.WriteLine(price);
                        return;
                    }
                }
            }
        }
        Console.WriteLine("Impossible");
    }
}
