// detail: https://codeforces.com/contest/950/submission/36107466
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
class P
{
    static void Main()
    {
        string life = Console.ReadLine();
        int count1 = 0;
        int count0 = 0;
        int renzoku1 = 0;
        bool can = true;
        bool lastis1 = false;
        int ban0 = 0;
        for (int i = 0; i < life.Length; i++)
        {
            if (life[i] == '0')
            {
                ban0--;
                count0++;
                lastis1 = false;
            }
            else
            {
                ban0++;
                count1++;
                if (lastis1) renzoku1++;
                lastis1 = true;
            }
            if (ban0 > 0) can = false;
        }
        ban0 = 0;
        for (int i = life.Length - 1; i >= 0; i--)
        {
            if (life[i] == '0')
            {
                ban0--;
            }
            else
            {
                ban0++;
            }
            if (ban0 > 0) can = false;
        }
        int substrCount = count0 - count1;
        if (!can)
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(substrCount);
        
        //次に0を追加すべき場所
        int next0 = 0;
        int next1 = 0;
        List<int>[] main = Enumerable.Repeat(0, substrCount).Select(x => new List<int>()).ToArray();
        for (int i = 0; i < life.Length; i++)
        {
            if (life[i] == '0')
            {
                if(next1 == 0)
                {
                    main[next0].Add(i + 1);
                    next0++;
                }
                else
                {
                    main[next1 - 1].Add(i + 1);
                    next1--;
                }
            }
            else
            {
                main[next1].Add(i + 1);
                next1++;
            }
        }
        Console.WriteLine(string.Join("\n", main.Select(x => $"{x.Count} {string.Join(" ", x)}").ToArray()));
    }
}