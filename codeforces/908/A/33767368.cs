// detail: https://codeforces.com/contest/908/submission/33767368
﻿using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string s = Console.ReadLine();
        int res = 0;
        char[] boin = { 'a', 'e', 'i', 'o', 'u' };
        foreach (var c in s)
        {
            if (boin.Contains(c) || (char.IsDigit(c) && (c - '0') % 2 == 1))
            {
                res++;
            }
        }
        Console.WriteLine(res);
    }
}