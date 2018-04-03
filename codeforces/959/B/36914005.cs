// detail: https://codeforces.com/contest/959/submission/36914005
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] nkm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string[] str = Console.ReadLine().Split();
        Dictionary<string, int> strind = new Dictionary<string, int>();
        for (int i = 0; i < str.Length; i++)
        {
            strind.Add(str[i], i);
        }
        int[] cost = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] group = new int[nkm[0]];
        int[] minInd = new int[nkm[1]];
        for (int i = 0; i < nkm[1]; i++)
        {
            int[] s = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            int min = -1;
            for (int j = 1; j < s.Length; j++)
            {
                group[s[j]] = i;
                if(min == -1 || cost[s[j]] < cost[min])
                {
                    min = s[j];
                }
            }
            minInd[i] = min;
        }
        string[] res = Console.ReadLine().Split();
        long re = 0;
        for (int i = 0; i < res.Length; i++)
        {
            re += cost[minInd[group[strind[res[i]]]]];
        }
        Console.WriteLine(re);

    }
}