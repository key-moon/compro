// detail: https://yukicoder.me/submissions/337701
//#define topt
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
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<int>[] neighbours = Enumerable.Repeat(0, nm[0]).Select(_ => new List<int>()).ToArray();
        for (int i = 0; i < nm[1]; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            neighbours[ab[0]].Add(ab[1]);
            neighbours[ab[1]].Add(ab[0]);
        }
        int q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            int query = int.Parse(Console.ReadLine()) - 1;

            var maxDepth = 0;
            var count = 0;

            Stack<Tuple<int, int, int>> stack = new Stack<Tuple<int, int, int>>();
            foreach (var neighbour in neighbours[query]) stack.Push(new Tuple<int, int, int>(neighbour, 0, query));
            while (stack.Count > 0)
            {
                var elem = stack.Pop();
                var index = elem.Item1;
                var depth = elem.Item2;
                var came = elem.Item3;
                count++;
                maxDepth = Max(maxDepth, depth);
                foreach (var neighbour in neighbours[index])
                {
                    if (neighbour == came) continue;
                    stack.Push(new Tuple<int, int, int>(neighbour, depth + 1, index));
                }
            }
            //1→2→4→8→16
            int depthLog = 0;
            while ((1 << depthLog) <= maxDepth) depthLog++;

            Console.WriteLine($"{count} {depthLog}");
        }
    }
}
