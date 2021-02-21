// detail: https://atcoder.jp/contests/arc113/submissions/20403712
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
#if DEBUG
        for (int l = 2; ; l++)
        {
            for (int cnt = 0; cnt < 500; cnt++)
            {

                var s = Gen(l);
                var ans = Stupid(s);
                var res = Solve(s);
                Debug.Assert(ans == res);
            }
        }
#endif

        //Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Console.WriteLine(Solve(Console.ReadLine()));
        }
        Console.Out.Flush();
    }
    static string Solve(string s)
    {
        var aCnt = s.Count(x => x == 'a');
        var bCnt = s.Length - aCnt;

        //aが二文字以上あり、aの後に文字がある→最適でない
        //aが一文字で、aの後ろに文字がある場合→反転させたい
        //最終的にbを含む形:
        //b..ba..a
        //b..babb
        //b..bab
        //a..a a..aからのみ
        if (aCnt == s.Length || bCnt == s.Length)
        {
            return s;
        }
        //ab..b これはa..ab..bからしか起きない
        //      aaaababbみたいなのから起きそうに感じるが、aを後ろに持っていく行動が強いのはそうなので勝手に後ろに行く
        //  aaaababb
        //   baaa bb
        //   ba   bb (baaaよりも強い)

        if (s.TrimStart('a').TrimEnd('b').Count() == 0)
        {
            var res = s.Substring(aCnt / 2 * 2);
            return res;
        }

        int[] aChunks;
        {
            List<int> compressed = new List<int>();
            int streak = 0;
            foreach (var c in s)
            {
                if (c == 'b' && streak != 0)
                {
                    compressed.Add(streak);
                    streak = 0;
                }
                if (c == 'a')
                {
                    streak++;
                }
            }
            if (streak != 0) compressed.Add(streak);
            aChunks = compressed.ToArray();
        }

        //aが偶数個の場合はbを全部残すを達成できるが
        //残した後にaがいくつかある方が強い
        //尻のbをaのreplaceのために消す必要はない
        //aが偶数個→絶対にbを使わないで
        //b..ba..a
        //を達成
        //baaabaaa
        //b baa aa
        //が最適 意外と難しい
        // b..bをB,a..aをAとする
        // ABA..BAとあった時、
        // ABABA→ ABBaa(aは使ったもの) とできる
        // 単体のaの時はそれを使うのは勿体ないが、単体でない場合は積極的に使うべき(補給される)

        if (aCnt % 2 == 0)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bCnt; i++)
                builder.Append('b');
            if (s.Last() != 'a')
            {
                return builder.ToString();
            }

            var lastCnt = aChunks.Last();
            foreach (var streak in aChunks.Reverse().Skip(1))
            {
                lastCnt += Max(streak - 2, 0);
            }
            if (lastCnt % 2 == 1) lastCnt--;
            for (int i = 0; i < lastCnt; i++)
                builder.Append('a');
            return builder.ToString();
        }

        //aが奇数個の場合
        //aが奇数個残る
        //できる限り後ろで残したい
        //ab..bのみは回避できるか?
        //これの回避は先頭と末尾のaを最初に使うことでできる
        //**↑これが最適とは限らないかも**
        //で、BaBになる その後にbを一度使って使ってBaにできる
        //なので、
        //  bbbbaaa 一度も使わない
        //  bbbab   一度も使わない
        //  bbabb   一度も使わない
        //  bbaaa   一度使っても良い (もちろん使わないほうが良い) 
        //  bba いつでもできる
        //Ba,Babb,Babの達成可能性を考える→達成できるならする
        //できないならgroupedの最適を考える
        //大切なこととして、今のaの場所以降にはできない
        //aが最後ならそこにgroup

        if (aCnt % 2 == 1)
        {
            StringBuilder builder = new StringBuilder();
            if (s[s.Length - 1] == 'a')
            {
                for (int i = 0; i < bCnt; i++)
                    builder.Append('b');
                var toUse = aChunks.Where(x => 2 <= x).ToList();
                //最後のchunkが1の時にそれは必須
                if (aChunks.Last() == 1) toUse.Add(1);
                var lastACnt = toUse.Sum() - (toUse.Count - 1) * 2;
                if (lastACnt % 2 == 0) lastACnt--;
                for (int i = 0; i < lastACnt; i++)
                    builder.Append('a');
                return builder.ToString();
            }
            if (2 <= s.Length && s[s.Length - 2] == 'a')
            {
                for (int i = 0; i < bCnt - 1; i++)
                    builder.Append('b');
                builder.Append('a');
                builder.Append('b');
                return builder.ToString();
            }
            if (3 <= s.Length && s[s.Length - 3] == 'a')
            {
                for (int i = 0; i < bCnt - 2; i++)
                    builder.Append('b');
                builder.Append('a');
                builder.Append('b');
                builder.Append('b');
                return builder.ToString();
            }
            {
                for (int i = 0; i < bCnt - 2; i++)
                    builder.Append('b');
                var toUse = aChunks.Where(x => 2 <= x).ToList();
                if (toUse.Count == 0) toUse.Add(1);
                var lastACnt = toUse.Sum() - (toUse.Count - 1) * 2;
                if (lastACnt % 2 == 0) lastACnt--;
                else if (toUse.Count == 1 && toUse.First() != 1 && s.First() == 'a' && aChunks.First() == toUse.First()) lastACnt -= 2;
                for (int i = 0; i < lastACnt; i++)
                    builder.Append('a');
                return builder.ToString();
            }
        }
        throw new Exception();
    }

    static string Gen(int len)
    {
        Random rng = new Random();
        return string.Join("", Enumerable.Range(0, len).Select(_ => rng.Next() % 2 == 0 ? 'a' : 'b'));
    }
    static Dictionary<string, string> dic = new Dictionary<string, string>();
    static string Stupid(string s)
    {
        if (dic.ContainsKey(s)) return dic[s];
        string totalRes = s;
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + 1; j < s.Length; j++)
            {
                if (s[i] != s[j]) continue;
                var arr = s.Where((x, y) => y != i && y != j).ToArray();
                Array.Reverse(arr, i, j - i - 1);
                var str = string.Join("", arr);
                var res = Stupid(str);
                if (totalRes.CompareTo(res) < 0) totalRes = res;
            }
        }
        return dic[s] = totalRes;
    }
}