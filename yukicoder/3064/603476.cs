// detail: https://yukicoder.me/submissions/603476
using System;
using System.Linq;

public static class P
{
    public static void Main()
    {
        var list = new[] { "う　し", "う　あ", "ん　笑", "た　ぷ", "く　ん", "ぷ　に", "し　き", "あ　く", "う　く", "あ　笑", "う　ん", "し　ぷ", "う　き", "く　笑", "う　笑", "に　き", "ぷ　笑", "た　き", "た　ん", "し　あ", "し　ん", "う　う", "う　た", "き　笑", "に　く", "笑　笑" };
        Console.WriteLine(string.Join("　", Console.ReadLine().Select(x => list[x - 'a'])) + "　");
    }
}