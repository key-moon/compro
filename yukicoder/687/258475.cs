// detail: https://yukicoder.me/submissions/258475
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                if (i + j == n)
                {
                    Console.WriteLine($"{i} {j}");
                    return;
                }
            }
        }
    }
}