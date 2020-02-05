// detail: https://yukicoder.me/submissions/426359
using System;

static class P
{
    static void Main()
    {
        var a = int.Parse(Console.ReadLine());
        var b = int.Parse(Console.ReadLine());
        Console.WriteLine(b <= (a + 1) * 50 ? 1 : 2);
    }
}