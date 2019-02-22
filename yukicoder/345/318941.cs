// detail: https://yukicoder.me/submissions/318941
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
        string s = Console.ReadLine();
        int min = 11192916;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                for (int k = j + 1; k < s.Length; k++)
                {
                    if (s[i] == 'c' && s[j] == 'w' && s[k] == 'w') min = Min(min, k - i + 1);
                }
            }
        }
        if (min > 1333) min = -1;
        Console.WriteLine(min);
    }
}
