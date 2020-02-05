// detail: https://yukicoder.me/submissions/426370
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        if (new int[]{ 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61 }.Contains(n))
        {
            Console.WriteLine("Sosu!");
        }
        else if (new int[] { 4, 9, 16, 25, 36, 49 }.Contains(n))
        {
            Console.WriteLine("Heihosu!");
        }
        else if (new int[] { 8, 27 }.Contains(n))
        {
            Console.WriteLine("Ripposu!");
        }
        else if (new int[] { 6, 28 }.Contains(n))
        {
            Console.WriteLine("Kanzensu!");
        }
        else
        {
            Console.WriteLine(n);
        }
    }
}