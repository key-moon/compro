// detail: https://codeforces.com/contest/786/submission/88277932
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;

public static class P
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).Skip(1).ToArray();
        var b = Console.ReadLine().Split().Select(int.Parse).Skip(1).ToArray();

        //ターンのときにそのマスにいて勝てるか
        int[] remainChoicesForA = Enumerable.Repeat(a.Length, n).ToArray();
        int[] remainChoicesForB = Enumerable.Repeat(b.Length, n).ToArray();

        int[] stateA = new int[n];
        int[] stateB = new int[n];

        stateA[0] = -1;
        stateB[0] = -1;
        remainChoicesForA[0] = 0;
        remainChoicesForB[0] = 0;
        Queue<Tuple<int, int>> loses = new Queue<Tuple<int, int>>();
        loses.Enqueue(new Tuple<int, int>(0, 0));
        loses.Enqueue(new Tuple<int, int>(0, 1));
        while (loses.Count != 0)
        {
            var lose = loses.Dequeue();
            var ind = lose.Item1;
            var person = lose.Item2;
            var myMoves = person == 0 ? a : b;
            var oppMoves = person == 0 ? b : a;
            var myState = person == 0 ? stateA : stateB;
            var oppState = person == 0 ? stateB : stateA;
            var myChoices = person == 0 ? remainChoicesForA : remainChoicesForB;
            foreach (var move in oppMoves)
            {
                var prev = (ind - move + n) % n;
                //if (prev != 0 && oppState[prev] == -1) throw new Exception();
                if (oppState[prev] != 0) continue;
                oppState[prev] = 1;
                foreach (var myMove in myMoves)
                {
                    var dead = (prev - myMove + n) % n;
                    myChoices[dead]--;
                    if (myChoices[dead] == 0)
                    {
                        myState[dead] = -1;
                        loses.Enqueue(new Tuple<int, int>(dead, person));
                    }
                }
            }
        }


        Console.WriteLine(string.Join(" ", stateA.Skip(1).Select(x => x == 0 ? "Loop" : x == 1 ? "Win" : "Lose")));
        Console.WriteLine(string.Join(" ", stateB.Skip(1).Select(x => x == 0 ? "Loop" : x == 1 ? "Win" : "Lose")));
    }
}
