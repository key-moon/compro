// detail: https://yukicoder.me/submissions/339943
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = nm[0];
        int m = nm[1];
        int[] cardCount = new int[n];
        int turn = 0;
        int turnOrder = 1;

        int last = 0;

        int streak = 0;
        int streakedNum = 0;
        foreach (var item in Enumerable.Repeat(0, m).Select(_ => Console.ReadLine()))
        {
            if (streakedNum != 0) 
            {
                if ((streakedNum == 2 && item != "drawtwo") || (streakedNum == 4 && item != "drawfour"))
                {
                    cardCount[turn] -= streakedNum * streak;
                    streak = 0;
                    streakedNum = 0;
                    turn = (turn + turnOrder + n) % n;
                }
            }
            last = turn;
            cardCount[turn]++;
            if (item == "skip")
            {
                turn = (turn + turnOrder + n) % n;
            }
            if (item == "reverse")
            {
                turnOrder *= -1;
            }
            if (item == "drawtwo")
            {
                streak++;
                streakedNum = 2;
            }
            if (item == "drawfour")
            {
                streak++;
                streakedNum = 4;
            }

            //ターン変更
            turn = (turn + turnOrder + n) % n;
        }
        Console.WriteLine($"{last + 1} {cardCount[last]}");
    }
}
