// detail: https://codeforces.com/contest/909/submission/33688747
﻿using System; 
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        Console.WriteLine(Layer(int.Parse(Console.ReadLine())));
    }
    static int Layer(int i)
    {
        if (i == 1) return 1;
        if (i == 2) return 2;
        return i + Layer(i - 2);
    }
}