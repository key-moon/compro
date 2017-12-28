// detail: https://codeforces.com/contest/911/submission/33717881
﻿using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int amin = a.Min();
        int aminIndex = a.ToList().IndexOf(amin);
        int mindist = int.MaxValue;
        for (int i = aminIndex + 1; i < a.Length; i++)
        {
            if (a[i] == amin)
            {
                mindist = Math.Min(mindist, i - aminIndex);
                aminIndex = i;
            }
        }
        Console.WriteLine(mindist);
    }
}