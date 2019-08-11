// detail: https://codeforces.com/contest/1200/submission/58577471
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using static System.Math;
using System.Runtime.CompilerServices;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        int[] rooms = new int[10];
        foreach (var c in s)
        {
            if (c == 'R')
            {
                for (int i = rooms.Length - 1; i >= 0; i--)
                {
                    if (rooms[i] == 0)
                    {
                        rooms[i] = 1;
                        break;
                    }
                }
            }
            else if (c == 'L')
            {
                for (int i = 0; i < rooms.Length; i++)
                {
                    if (rooms[i] == 0)
                    {
                        rooms[i] = 1;
                        break;
                    }
                }
            }
            else
            {
                rooms[c - '0'] = 0;
            }
        }
        Console.WriteLine(string.Join("", rooms));
    }
}
