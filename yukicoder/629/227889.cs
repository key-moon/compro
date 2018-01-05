// detail: https://yukicoder.me/submissions/227889
using System;
using System.Linq;
using System.Collections.Generic;

class P
{
    static void Main()
    {
        int[] NM = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] vertex = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[][] path = new int[NM[1]][].Select(_ => Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray()).ToArray();
        int[] vertbig = new int[vertex.Length];
        int[] vertsmall = new int[vertex.Length];
        foreach (var i in path)
        {
            if(vertex[i[0]] < vertex[i[1]])
            {
                if (vertbig[i[1]] != 0 && vertbig[i[1]] != vertex[i[0]])
                {
                    Console.WriteLine("YES");
                    return;
                }
                if (vertsmall[i[0]] != 0 && vertsmall[i[0]] != vertex[i[1]])
                {
                    Console.WriteLine("YES");
                    return;
                }
                vertbig[i[1]] = vertex[i[0]];
                vertsmall[i[0]] = vertex[i[1]];
            }
            else if (vertex[i[0]] > vertex[i[1]])
            {
                if (vertbig[i[0]] != 0 && vertbig[i[0]] != vertex[i[1]])
                {
                    Console.WriteLine("YES");
                    return;
                }
                if (vertsmall[i[1]] != 0 && vertsmall[i[1]] != vertex[i[0]])
                {
                    Console.WriteLine("YES");
                    return;
                }
                vertbig[i[0]] = vertex[i[1]];
                vertsmall[i[1]] = vertex[i[0]];
            }
        }
        Console.WriteLine("NO");
    }
}