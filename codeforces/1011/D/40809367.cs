// detail: https://codeforces.com/contest/1011/submission/40809367
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

class P
{
    static void Main()
    {
        int[] mn = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //60回しか聞けないよ
        //30回で列取得、31から
        bool[] p = new bool[mn[1]];
        for (int i = 0; i < mn[1]; i++)
        {
            Console.WriteLine(1);
            string res = Console.ReadLine();
            if (res == "0") return;
            p[i] = res == "1";
        }
        int min = 0;
        int max = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, 1073741824 }.Where(x => x > mn[0]).First();
        for (int i = 0; i < 1333; i++)
        {
            Console.WriteLine(Min(mn[0], (min + max) / 2));
            string res = Console.ReadLine();

            if(!(res == "1" ^ p[i % mn[1]]))
            {
                min += (max - min) / 2;
            }
            else if(!(res == "-1" ^ p[i % mn[1]]))
            {
                max -= (max - min) / 2;
            }
            else
            {
                return;
            }
        }
    }
}