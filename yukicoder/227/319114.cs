// detail: https://yukicoder.me/submissions/319114
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

class P
{
    static void Main()
    {
        var pair = Console.ReadLine().Split().Select(int.Parse).GroupBy(x => x).OrderByDescending(x => x.Count()).ToArray();
        string hand = "NO HAND";
        if (pair.Count() != 1)
        {
            if (pair[0].Count() == 3 && pair[1].Count() == 2) hand = "FULL HOUSE";
            else if (pair[0].Count() == 3) hand = "THREE CARD";
            else if (pair[0].Count() == 2 && pair[1].Count() == 2) hand = "TWO PAIR";
            else if (pair[0].Count() == 2) hand = "ONE PAIR";
        }
        Console.WriteLine(hand);
    }
}
