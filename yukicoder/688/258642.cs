// detail: https://yukicoder.me/submissions/258642
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;

class P
{
    static List<long> pow = new List<long>(){ 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912 };
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        if (n == 0) Console.WriteLine("1\n0");
        //1の数
        for (int i = 2; i <= 30; i++)
        {
            long p = (i * (i - 1) / 2);
            if (n % p != 0) continue;
            if (!pow.Contains(n / p)) continue;
            int index = pow.IndexOf(n / p);
            if (i + index > 30) continue;
            Console.WriteLine(index + i);
            Console.WriteLine(string.Join(" ", Enumerable.Repeat('1', i).Concat(Enumerable.Repeat('0', index))));
            return;
        }
    }
}