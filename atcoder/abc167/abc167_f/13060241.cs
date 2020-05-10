// detail: https://atcoder.jp/contests/abc167/submissions/13060241
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
        Bracket[] brackets = new Bracket[n];
        for (int i = 0; i < n; i++)
        {
            var s = Console.ReadLine();
            int depth = 0;
            int minDepth = 0;
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '(') depth++;
                else depth--;
                minDepth = Min(minDepth, depth);
            }
            brackets[i] = new Bracket() { FinalDepth = depth, MinDepth = minDepth };
        }
        {
            int depth = 0;
            //先に深い方からやった方が得することがあるかというとそんなことはなくて、そんな暇があったら浅いのをやれてしまうので
            //最初は途中での深さが浅いのから
            foreach (var item in brackets.Where(x => x.FinalDepth >= 0).OrderByDescending(x => x.MinDepth))
            {
                if (depth + item.MinDepth < 0) { Console.WriteLine("No"); return; }
                depth += item.FinalDepth;
            }
            //先に浅いのをやることが得になりうるか
            //さっきのの逆、なので途中での深さが深いのから
            foreach (var item in brackets.Where(x => x.FinalDepth < 0).OrderBy(x => x.MinDepth - x.FinalDepth))
            {
                if (depth + item.MinDepth < 0) { Console.WriteLine("No"); return; }
                depth += item.FinalDepth;
            }
            if (depth != 0) { Console.WriteLine("No"); return; }
        }
        //弾かなくて良いものを弾いている
        //throw new Exception();
        Console.WriteLine("Yes");
    }
}

struct Bracket
{
    public int FinalDepth;
    public int MinDepth;
}
