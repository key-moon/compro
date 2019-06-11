// detail: https://codeforces.com/contest/1182/submission/55449439
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;

static class P
{
    static void Main()
    {
        int[] vowelCodes = new int['z'];
        vowelCodes['a'] = 0;
        vowelCodes['i'] = 1;
        vowelCodes['u'] = 2;
        vowelCodes['e'] = 3;
        vowelCodes['o'] = 4;

        var n = int.Parse(Console.ReadLine());
        var s = Enumerable.Repeat(0, n).Select(_ => Console.ReadLine()).ToArray();
        //母音の数、最後の母音
        var words = s.Select((x, index) => new Word(x.Count(IsVowel), vowelCodes[x.Last(IsVowel)], index)).ToArray();

        var groupedByCount = words.GroupBy(x => x.VowelCount).Select(x => x.ToArray()).ToArray();
        List<Tuple<Word, Word>> vowelPairs = new List<Tuple<Word, Word>>();
        List<Tuple<Word, Word>> misMatchVowelPairs = new List<Tuple<Word, Word>>();
        foreach (var sameCountWords in groupedByCount)
        {
            List<Word> remain = new List<Word>();
            Word last = default(Word);
            foreach (var sameVowels in sameCountWords.GroupBy(x => x.LastVowel))
            {
                last = default(Word);
                foreach (var item in sameVowels)
                {
                    if (last.VowelCount == 0) last = item;
                    else
                    {
                        vowelPairs.Add(new Tuple<Word, Word>(last, item));
                        last = default(Word);
                    }
                }
                if (last.VowelCount != 0)
                {
                    remain.Add(last);
                }
            }
            last = default(Word);
            foreach (var item in remain)
            {
                if (last.VowelCount == 0) last = item;
                else
                {
                    misMatchVowelPairs.Add(new Tuple<Word, Word>(last, item));
                    last = default(Word);
                }
            }
        }
        List<string> builder = new List<string>();
        int ptr = 0;
        while (ptr < misMatchVowelPairs.Count && ptr < vowelPairs.Count)
        {
            builder.Add($"{s[misMatchVowelPairs[ptr].Item1.Index]} {s[vowelPairs[ptr].Item1.Index]}");
            builder.Add($"{s[misMatchVowelPairs[ptr].Item2.Index]} {s[vowelPairs[ptr].Item2.Index]}");
            ptr++;
        }
        while (ptr + 1 < vowelPairs.Count)
        {
            builder.Add($"{s[vowelPairs[ptr].Item1.Index]} {s[vowelPairs[ptr + 1].Item1.Index]}");
            builder.Add($"{s[vowelPairs[ptr].Item2.Index]} {s[vowelPairs[ptr + 1].Item2.Index]}");
            ptr += 2;
        }
        Console.WriteLine(builder.Count / 2);
        Console.WriteLine(string.Join("\n", builder));
    }
    static bool IsVowel(char c) => c == 'a' || c == 'i' || c == 'u' || c == 'e' || c == 'o';
}

struct Word
{
    public int VowelCount;
    public int LastVowel;
    public int Index;
    public Word(int vowels, int lastVowel, int index)
    {
        VowelCount = vowels;
        LastVowel = lastVowel;
        Index = index;
    }
}