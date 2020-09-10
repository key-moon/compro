// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/3509/judge/4826899/C#
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static Reader;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
	public static void Main()
	{
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
		int n = NextInt, q = NextInt;
		long[] degree = new long[n];

		HashSet<int>[] adjs = Enumerable.Repeat(0, n).Select(_ => new HashSet<int>()).ToArray();

		long curRes = 0;
		for (int i = 0; i < q; i++)
		{
			int u = NextInt, v = NextInt;
			u--; v--;

			long degSum;

			degSum = 0;
			foreach (var adj in adjs[u]) degSum += degree[adj];
			curRes -= degSum * degree[u];

			degSum = 0;
			foreach (var adj in adjs[v]) degSum += degree[adj];
			curRes -= degSum * degree[v];

			bool inserted = adjs[u].Add(v) && adjs[v].Add(u);
			if (!inserted)
			{
				adjs[u].Remove(v);
				adjs[v].Remove(u);
			}
			if (!inserted) curRes += degree[u] * degree[v];

			var incr = inserted ? 1 : -1;
			degree[u] += incr;
			degree[v] += incr;

			degSum = 0;
			foreach (var adj in adjs[u]) degSum += degree[adj];
			curRes += degSum * degree[u];

			degSum = 0;
			foreach (var adj in adjs[v]) degSum += degree[adj];
			curRes += degSum * degree[v];

			if (inserted) curRes -= degree[u] * degree[v];

            Console.WriteLine(curRes);
		}
		Console.Out.Flush();
	}
}


static class Reader
{
    const int BUF_SIZE = 1 << 12;
    static Stream Stream = Console.OpenStandardInput();
    static byte[] Buffer = new byte[BUF_SIZE];
    static int ptr = BUF_SIZE - 1;
    static void Move() { if (++ptr >= Buffer.Length) { Stream.Read(Buffer, 0, BUF_SIZE); ptr = 0; } }


    public static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0; while (Buffer[ptr] < 48) Move();
            do { res = res * 10 + (int)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
            return res;
        }
    }
}

