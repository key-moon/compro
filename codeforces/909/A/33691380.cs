// detail: https://codeforces.com/contest/909/submission/33691380
﻿using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        string[] s = Console.ReadLine().Split();

        string res = s[0][0].ToString();
        for (int i = 1; i < s[0].Length; i++)
        {
            if (s[1][0] > s[0][i])
            {
                res += s[0][i];
            }
            else
            {
                break;
            }
        }
        res += s[1][0];
        Console.WriteLine(res);
    }
}