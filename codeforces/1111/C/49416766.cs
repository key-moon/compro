// detail: https://codeforces.com/contest/1111/submission/49416766
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
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int[] nkab = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        //z地を2つに等分する、
        //基地を壊す あべんじゃーがいなかったらA，いたらB*あべんじゃーの数*長さ
        //aはあべんじゃーがいる場所
        //
        Console.WriteLine(getCost(1 << nkab[0], nkab[2], nkab[3], a));
    }
    static long getCost(int length, long a, long b, List<int> places)
    {
        if (places.Count == 0) return a;

        var burnCost = b * places.Count * length;
        if (length == 1) return burnCost;
        List<int> firstp = new List<int>();
        List<int> secondp = new List<int>();
        foreach (var place in places)
        {
            if (place <= length / 2) firstp.Add(place);
            else secondp.Add(place - length / 2);
        }
        ;
        var separateCost = getCost(length / 2, a, b, firstp) + getCost(length / 2, a, b, secondp);
        return Min(burnCost, separateCost);
    }
}
