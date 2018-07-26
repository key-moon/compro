// detail: https://codeforces.com/contest/1011/submission/40801565
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] seq = new int[n * 2];
        for (int i = 1; i < n; i++)
        {
            seq[i * 2 - 1] = b[i];
            seq[i * 2] = a[i];
        }
        seq[0] = a[0];
        seq[seq.Length - 1] = b[0];
        if(seq.Min() <= 1)
        {
            Console.WriteLine(-1);
            return;
        }
        double min = 0;
        double max = int.MaxValue;
        double fuel = (max + min) / 2;
        for (int _ = 0; _ < 60; _++)
        {
            fuel = (max + min) / 2;
            double weight = m + fuel;
            bool isEnough = true;
            for (int i = 0; i < seq.Length; i++)
            {
                weight -= weight / seq[i];
                if (weight < m)
                {
                    isEnough = false;
                    break;
                }
            }

            if (isEnough)
            {
                max -= (max - min) / 2;
            }
            else
            {
                min += (max - min) / 2;
            }
        }
        Console.WriteLine(fuel.ToString(System.Globalization.CultureInfo.InvariantCulture));
    }
}