// detail: https://codeforces.com/contest/911/submission/33730465
﻿using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] ABC = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (ABC.Count(x => x == 2) >= 2 || ABC.Contains(1) || ABC.Count(x => x == 3) == 3 || (ABC.Contains(2) && ABC.Count(x => x == 4) == 2))
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
        /*int n = 30;
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                for (int k = 1; k < n; k++)
                {
                    A(new int[] { i, j, k });
                }
            }
        }*/
    }
    static void A(int[] ABC)
    {
        bool res = false;
        for (int i = 0; i < ABC[0]; i++)
        {
            for (int j = 0; j < ABC[1]; j++)
            {
                for (int k = 0; k < ABC[2]; k++)
                {
                    bool pokapoka = true;
                    for (int l = 0; l < 10; l++)
                    {
                        if (!(l % ABC[0] == i || l % ABC[1] == j || l % ABC[2] == k))
                        {
                            pokapoka = false;
                        }
                    }
                    if (pokapoka)
                    {
                        res = true;
                        goto end;
                    }
                }
            }
        }
        end:;
        if (res != (ABC.Count(x => x == 2) >= 2 || ABC.Contains(1) || ABC.Count(x => x == 3) == 3 || (ABC.Contains(2) && ABC.Count(x => x == 4) == 2)))
        {
            Console.WriteLine($"{ABC[0]} {ABC[1]} {ABC[2]}");
        }
    }
}