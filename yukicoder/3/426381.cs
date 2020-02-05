// detail: https://yukicoder.me/submissions/426381
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
        int n = int.Parse(Console.ReadLine());
        int[] step = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        step[1] = 1;
        while (queue.Count > 0)
        {
            var elem = queue.Dequeue();
            var popCount = PopCount(elem);

            if (1 <= elem - popCount) 
                if (step[elem] + 1 < step[elem - popCount])
                {
                    queue.Enqueue(elem - popCount);
                    step[elem - popCount] = step[elem] + 1;
                }

            if (elem + popCount < step.Length)
                if (step[elem] + 1 < step[elem + popCount])
                {
                    queue.Enqueue(elem + popCount);
                    step[elem + popCount] = step[elem] + 1;
                }
        }
        if (step.Last() == int.MaxValue)
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(step.Last());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int PopCount(int n)
    {
        n = n - ((n >> 1) & 0x55555555);
        n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
        return (int)(((n + (n >> 4) & 0xF0F0F0F) * 0x1010101) >> 24);
    }
}