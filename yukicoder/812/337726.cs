// detail: https://yukicoder.me/submissions/337726
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

            HashSet<int> arrived = new HashSet<int>();
            arrived.Add(query);

            Queue<Tuple<int, int>> stack = new Queue<Tuple<int, int>>();
            foreach (var neighbour in neighbours[query])
            {
                arrived.Add(neighbour);
                stack.Enqueue(new Tuple<int, int>(neighbour, 0));
            }
            while (stack.Count > 0)
            {
                var elem = stack.Dequeue();
                var index = elem.Item1;
                var depth = elem.Item2;
                count++;
                maxDepth = Max(maxDepth, depth);
                foreach (var neighbour in neighbours[index])
                {
                    if (arrived.Contains(neighbour)) continue;
                    arrived.Add(neighbour);
                    stack.Enqueue(new Tuple<int, int>(neighbour, depth + 1));
                }
            }
            int depthLog = 0;
            while ((1 << depthLog) <= maxDepth) depthLog++;

            Console.WriteLine($"{count} {depthLog}");
        }
    }
}
