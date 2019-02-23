// detail: https://yukicoder.me/submissions/319207
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
        int h = 0;
        int w = 0;
        foreach (var item in Console.ReadLine())
        {
            switch (item)
            {
                case 'N':
                    h++;
                    break;
                case 'E':
                    w++;
                    break;
                case 'W':
                    w--;
                    break;
                case 'S':
                    h--;
                    break;
            }
        }
        Console.WriteLine(Sqrt(h * h + w * w));
    }
}
