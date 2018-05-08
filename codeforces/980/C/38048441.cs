// detail: https://codeforces.com/contest/980/submission/38048441
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] group = Enumerable.Repeat(-1, 256).ToArray();
        bool[] isAccure = new bool[256];
        for (int i = 0; i < p.Length; i++)
        {
            if(!isAccure[p[i]])
            {
                int key = -1;
                if (group[p[i]] != -1)
                {
                    key = group[p[i]];
                }
                else
                {
                    for (int j = Max(0, p[i] - nk[1] + 1); j <= p[i]; j++)
                    {
                        if (!isAccure[j])
                        {
                            key = j;
                            break;
                        }
                    }
                }
                for (int j = key; j < Min(key + nk[1],256); j++)
                {
                    if (!isAccure[j])
                    {
                        group[j] = key;
                        isAccure[j] = j <= p[i];
                    }
                }
            }
            p[i] = group[p[i]];
        }
        if (p.Contains(-1)) throw new Exception();
        Console.WriteLine(string.Join(" ", p));
    }
}