// detail: https://atcoder.jp/contests/abc141/submissions/16604086
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace AtCoder
{
	public class Program
	{
		static void Main()
		{
			using var cin = new Scanner();
			int n = cin.Int();
			string s = cin.Next();

			int ans = 0;
			for (int i = 0; i < n; i++)
			{
				string ss = s[i..n];
				var lcp = ZAlgorithm(ss);
				for (int j = 0; j < lcp.Length; j++)
				{
					if (j + i >= lcp[j] + i)
					{
						ans = Math.Max(ans, lcp[j]);
					}
				}
			}

			Console.WriteLine(ans);
		}

		/// <summary>
		/// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
		/// </summary>
		/// <remarks>
		/// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
		/// <para>計算量: O(|<paramref name="s"/>|)</para>
		/// </remarks>
		public static int[] ZAlgorithm<T>(ReadOnlySpan<T> s)
		{
			int n = s.Length;
			if (n == 0) return new int[] { };
			int[] z = new int[n];
			z[0] = 0;
			for (int i = 1, j = 0; i < n; i++)
			{
				ref int k = ref z[i];
				k = (j + z[j] <= i) ? 0 : System.Math.Min(j + z[j] - i, z[i - j]);
				while (i + k < n && EqualityComparer<T>.Default.Equals(s[k], s[i + k])) k++;
				if (j + z[j] < i + z[i]) j = i;
			}
			z[0] = n;
			return z;
		}

		/// <summary>
		/// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
		/// </summary>
		/// <remarks>
		/// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
		/// <para>計算量: O(|<paramref name="s"/>|)</para>
		/// </remarks>
		public static int[] ZAlgorithm(string s) => ZAlgorithm(s.AsSpan());

		/// <summary>
		/// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
		/// </summary>
		/// <remarks>
		/// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
		/// <para>計算量: O(|<paramref name="s"/>|)</para>
		/// </remarks>
		public static int[] ZAlgorithm(int[] s) => ZAlgorithm(s);

		/// <summary>
		/// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
		/// </summary>
		/// <remarks>
		/// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
		/// <para>計算量: O(|<paramref name="s"/>|)</para>
		/// </remarks>
		public static int[] ZAlgorithm(uint[] s) => ZAlgorithm(s);

		/// <summary>
		/// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
		/// </summary>
		/// <remarks>
		/// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
		/// <para>計算量: O(|<paramref name="s"/>|)</para>
		/// </remarks>
		public static int[] ZAlgorithm(long[] s) => ZAlgorithm(s);

		/// <summary>
		/// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
		/// </summary>
		/// <remarks>
		/// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
		/// <para>計算量: O(|<paramref name="s"/>|)</para>
		/// </remarks>
		public static int[] ZAlgorithm(ulong[] s) => ZAlgorithm(s);
	}

	public class HashMap<TKey, TValue> : Dictionary<TKey, TValue>
	{
		private readonly Func<TKey, TValue> initialzier_;
		public HashMap(Func<TKey, TValue> initialzier)
			: base()
		{
			initialzier_ = initialzier;
		}

		public HashMap(Func<TKey, TValue> initialzier, int capacity)
			: base(capacity)
		{
			initialzier_ = initialzier;
		}

		new public TValue this[TKey key]
		{
			get
			{
				if (ContainsKey(key) == false)
				{
					base[key] = initialzier_(key);
				}

				return base[key];
			}

			set { base[key] = value; }
		}
	}

	public struct ModInt
	{
		public const long P = 1000000007;
		//public const long P = 998244353;

		public static ModInt Inverse(ModInt value) => Pow(value, P - 2);
		public static ModInt Pow(ModInt value, long k) => Pow(value.value_, k);
		public static ModInt Pow(long value, long k)
		{
			long ret = 1;
			for (k %= P - 1; k > 0; k >>= 1, value = value * value % P)
			{
				if ((k & 1) == 1)
				{
					ret = ret * value % P;
				}
			}
			return new ModInt(ret);
		}

		private long value_;

		public ModInt(long value)
			=> value_ = value;
		public ModInt(long value, bool mods)
		{
			if (mods)
			{
				value %= P;
				if (value < 0)
				{
					value += P;
				}
			}

			value_ = value;
		}

		public static ModInt operator +(ModInt lhs, ModInt rhs)
		{
			lhs.value_ = (lhs.value_ + rhs.value_) % P;
			return lhs;
		}
		public static ModInt operator +(long lhs, ModInt rhs)
		{
			rhs.value_ = (lhs + rhs.value_) % P;
			return rhs;
		}
		public static ModInt operator +(ModInt lhs, long rhs)
		{
			lhs.value_ = (lhs.value_ + rhs) % P;
			return lhs;
		}

		public static ModInt operator -(ModInt lhs, ModInt rhs)
		{
			lhs.value_ = (P + lhs.value_ - rhs.value_) % P;
			return lhs;
		}
		public static ModInt operator -(long lhs, ModInt rhs)
		{
			rhs.value_ = (P + lhs - rhs.value_) % P;
			return rhs;
		}
		public static ModInt operator -(ModInt lhs, long rhs)
		{
			lhs.value_ = (P + lhs.value_ - rhs) % P;
			return lhs;
		}

		public static ModInt operator *(ModInt lhs, ModInt rhs)
		{
			lhs.value_ = lhs.value_ * rhs.value_ % P;
			return lhs;
		}
		public static ModInt operator *(long lhs, ModInt rhs)
		{
			rhs.value_ = lhs * rhs.value_ % P;
			return rhs;
		}
		public static ModInt operator *(ModInt lhs, long rhs)
		{
			lhs.value_ = lhs.value_ * rhs % P;
			return lhs;
		}

		public static ModInt operator /(ModInt lhs, ModInt rhs)
		{
			long exp = P - 2;
			while (exp > 0)
			{
				if (exp % 2 > 0)
				{
					lhs *= rhs;
				}

				rhs *= rhs;
				exp /= 2;
			}

			return lhs;
		}

		public static implicit operator ModInt(long n) => new ModInt(n, true);
		public long ToLong() => value_;
		public override string ToString() => value_.ToString();
	}

	public static class Helper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UpdateMin<T>(ref T target, T value) where T : IComparable<T>
			=> target = target.CompareTo(value) > 0 ? value : target;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UpdateMin<T>(ref T target, T value, Action<T> onUpdated) where T : IComparable<T>
		{
			if (target.CompareTo(value) > 0)
			{
				target = value;
				onUpdated(value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UpdateMax<T>(ref T target, T value) where T : IComparable<T>
			=> target = target.CompareTo(value) < 0 ? value : target;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void UpdateMax<T>(ref T target, T value, Action<T> onUpdated) where T : IComparable<T>
		{
			if (target.CompareTo(value) < 0)
			{
				target = value;
				onUpdated(value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] Array<T>(int n, Func<int, T> init)
			=> Enumerable.Range(0, n).Select(x => init(x)).ToArray();
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static List<T> List<T>(int n, Func<int, T> init)
			=> Enumerable.Range(0, n).Select(x => init(x)).ToList();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,] Array2<T>(int n, int m, T init)
			where T : struct
		{
			var array = new T[n, m];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					array[i, j] = init;
				}
			}

			return array;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,] Array2<T>(int n, int m, Func<int, int, T> initializer)
		{
			var array = new T[n, m];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					array[i, j] = initializer(i, j);
				}
			}

			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,] Array3<T>(int n1, int n2, int n3, T init)
			where T : struct
		{
			var array = new T[n1, n2, n3];
			for (int i1 = 0; i1 < n1; i1++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					for (int i3 = 0; i3 < n3; i3++)
					{
						array[i1, i2, i3] = init;
					}
				}
			}

			return array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[,,,] Array4<T>(int n1, int n2, int n3, int n4, T init)
			where T : struct
		{
			var array = new T[n1, n2, n3, n4];
			for (int i1 = 0; i1 < n1; i1++)
			{
				for (int i2 = 0; i2 < n2; i2++)
				{
					for (int i3 = 0; i3 < n3; i3++)
					{
						for (int i4 = 0; i4 < n4; i4++)
						{
							array[i1, i2, i3, i4] = init;
						}
					}
				}
			}

			return array;
		}

		private static readonly int[] delta4_ = { 1, 0, -1, 0, 1 };
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DoAt4(int i, int j, int imax, int jmax, Action<int, int> action)
		{
			for (int dn = 0; dn < 4; dn++)
			{
				int d4i = i + delta4_[dn];
				int d4j = j + delta4_[dn + 1];
				if ((uint)d4i < (uint)imax && (uint)d4j < (uint)jmax)
				{
					action(d4i, d4j);
				}
			}
		}

		private static readonly int[] delta8_ = { 1, 0, -1, 0, 1, 1, -1, -1, 1 };
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DoAt8(int i, int j, int imax, int jmax, Action<int, int> action)
		{
			for (int dn = 0; dn < 8; dn++)
			{
				int d8i = i + delta8_[dn];
				int d8j = j + delta8_[dn + 1];
				if ((uint)d8i < (uint)imax && (uint)d8j < (uint)jmax)
				{
					action(d8i, d8j);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ForEachSubBit(int bit, Action<int> action)
		{
			for (int sub = bit; sub >= 0; sub--)
			{
				sub &= bit;
				action(sub);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string Reverse(string src)
		{
			var chars = src.ToCharArray();
			for (int i = 0, j = chars.Length - 1; i < j; i++, j--)
			{
				var tmp = chars[i];
				chars[i] = chars[j];
				chars[j] = tmp;
			}
			return new string(chars);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string Join<T>(this IEnumerable<T> values, string separator = "")
			=> string.Join(separator, values);
	}

	public class Scanner : IDisposable
	{
		private readonly char delimiter_ = ' ';
		private readonly string filePath_;
		private readonly StreamReader sr_;
		private string[] buf_;
		private int index_;

		public Scanner(string file = "")
		{
			if (string.IsNullOrWhiteSpace(file))
			{
				sr_ = new StreamReader(Console.OpenStandardInput());
			}
			else
			{
				filePath_ = file;
				sr_ = new StreamReader(file);
			}

			Console.SetOut(new StreamWriter(Console.OpenStandardOutput())
			{
				AutoFlush = false
			});
			buf_ = new string[0];
			index_ = 0;
		}

		public void Dispose()
		{
			Console.Out.Flush();
			sr_.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string NextLine() => sr_.ReadLine();
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string Next()
		{
			if (index_ < buf_.Length)
			{
				return buf_[index_++];
			}

			string st = sr_.ReadLine();
			while (st == "")
			{
				st = sr_.ReadLine();
			}

			buf_ = st.Split(delimiter_, StringSplitOptions.RemoveEmptyEntries);
			if (buf_.Length == 0)
			{
				return Next();
			}

			index_ = 0;
			return buf_[index_++];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Int() => int.Parse(Next());
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Int(int offset) => int.Parse(Next()) + offset;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (int, int) Int2(int offset = 0)
			=> (Int(offset), Int(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (int, int, int) Int3(int offset = 0)
			=> (Int(offset), Int(offset), Int(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (int, int, int, int) Int4(int offset = 0)
			=> (Int(offset), Int(offset), Int(offset), Int(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int[] ArrayInt(int length, int offset = 0)
		{
			int[] Array = new int[length];
			for (int i = 0; i < length; i++)
			{
				Array[i] = Int(offset);
			}
			return Array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long Long() => long.Parse(Next());
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long Long(long offset) => long.Parse(Next()) + offset;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (long, long) Long2(long offset = 0)
			=> (Long(offset), Long(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (long, long, long) Long3(long offset = 0)
			=> (Long(offset), Long(offset), Long(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (long, long, long, long) Long4(long offset = 0)
			=> (Long(offset), Long(offset), Long(offset), Long(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long[] ArrayLong(int length, long offset = 0)
		{
			long[] Array = new long[length];
			for (int i = 0; i < length; i++)
			{
				Array[i] = Long(offset);
			}
			return Array;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Double() => double.Parse(Next());
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Double(double offset) => double.Parse(Next()) + offset;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (double, double) Double2(double offset = 0)
			=> (Double(offset), Double(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (double, double, double) Double3(double offset = 0)
			=> (Double(offset), Double(offset), Double(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (double, double, double, double) Double4(double offset = 0)
			=> (Double(offset), Double(offset), Double(offset), Double(offset));
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double[] ArrayDouble(int length, double offset = 0)
		{
			double[] Array = new double[length];
			for (int i = 0; i < length; i++)
			{
				Array[i] = Double(offset);
			}
			return Array;
		}

		public void Save(string text)
		{
			if (string.IsNullOrWhiteSpace(filePath_))
			{
				return;
			}

			File.WriteAllText(filePath_ + "_output.txt", text);
		}
	}
}
