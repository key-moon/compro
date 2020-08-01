// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2582/judge/4728107/C#
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
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0) break;

            bool l = false;
            bool r = false;
            int lastState = 0;
            int res = 0;
            foreach (var item in Console.ReadLine().Split())
            {
                switch (item)
                {
                    case "lu":
                        l = true;
                        break;
                    case "ru":
                        r = true;
                        break;
                    case "ld":
                        l = false;
                        break;
                    case "rd":
                        r = false;
                        break;
                }
                if (l && r && lastState == 0)
                {
                    lastState = 1;
                    res++;
                }
                if (!l && !r && lastState == 1)
                {
                    lastState = 0;
                    res++;
                }
            }
            Console.WriteLine(res);
        }
    }
}
