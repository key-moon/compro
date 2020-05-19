// detail: https://atcoder.jp/contests/past202004-open/submissions/13400666
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AtCoder
{
    partial class Program
    {
        static long mod = 1000000007;
        static void Swap<T>(ref T a, ref T b) { T temp = a; a = b; b = temp; }
        static void Main()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
            Solve();
            Console.Out.Flush();
            Console.ReadKey();
        }

        //ここから

        static void Solve()
        {
            var S = GetStr();
            long cnt = 0;
            for (char i = 'a'; i <= 'z' + 1; i++)
            {
                if (IsMatch(new string(new char[] { i }))) cnt++;
                for (char j = 'a'; j <= 'z' + 1; j++)
                {
                    if (IsMatch(new string(new char[] { i, j }))) cnt++;
                    for (char k = 'a'; k <= 'z' + 1; k++)
                    {
                        if (IsMatch(new string(new char[] { i, j, k }))) cnt++;
                    }
                }
            }

            bool IsMatch(string T)
            {
                var len = T.Length;
                for (int i = 0; i < S.Length - len + 1; i++)
                {
                    var ok = true;
                    for (int j = 0; j < len; j++)
                    {
                        if (S[i + j] != T[j] && T[j] != 'z' + 1)
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                    {
                        return true;
                    }
                }
                return false;
            }

            Console.WriteLine(cnt);
        }

    }


    public static class Ex
    {
        public static List<string> FastSort(this List<string> s) { s.Sort(StringComparer.Ordinal); return s.ToList(); }
        public static string yesno(this bool b) { return b ? "yes" : "no"; }
        public static string YesNo(this bool b) { return b ? "Yes" : "No"; }
        public static string YESNO(this bool b) { return b ? "YES" : "NO"; }
    }

    partial class Program
    {
        static public string GetStr() { return Console.ReadLine().Trim(); }
        static public char GetChar() { return Console.ReadLine().Trim()[0]; }
        static public int GetInt() { return int.Parse(Console.ReadLine().Trim()); }
        static public long GetLong() { return long.Parse(Console.ReadLine().Trim()); }
        static public double GetDouble() { return double.Parse(Console.ReadLine().Trim()); }
        static public string[] GetStrArray() { return Console.ReadLine().Trim().Split(' '); }
        static public int[] GetIntArray() { return Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray(); }
        static public long[] GetLongArray() { return Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray(); }
        static public char[] GetCharArray() { return Console.ReadLine().Trim().Split(' ').Select(char.Parse).ToArray(); }
        static public double[] GetDoubleArray() { return Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray(); }
        static public T[][] CreateJaggedArray<T>(int H, int W, T value) { return Enumerable.Repeat(0, H).Select(s => Enumerable.Repeat(value, W).ToArray()).ToArray(); }
        static public int[][] GetIntJaggedArray(int N) { return Enumerable.Repeat(0, N).Select(s => GetIntArray().ToArray()).ToArray(); }
        static public long[][] GetLongJaggedArray(int N) { return Enumerable.Repeat(0, N).Select(s => GetLongArray().ToArray()).ToArray(); }
        static public char[][] GetCharJaggedArray(int N) { return Enumerable.Repeat(0, N).Select(s => GetStr().ToCharArray()).ToArray(); }
        static public double[][] GetDoubleJaggedArray(int N) { return Enumerable.Repeat(0, N).Select(s => GetDoubleArray()).ToArray(); }


        static public void WriteObjects<T>(IReadOnlyCollection<T> values) { var array = values.ToArray(); var num = array.Length; if (num == 0) return; Console.Write(array[0]); for (int i = 1; i < num; i++) { Console.Write(" " + array[i]); } Console.WriteLine(); }

        static bool eq<T, U>() => typeof(T).Equals(typeof(U));
        static T ct<T, U>(U a) => (T)Convert.ChangeType(a, typeof(T));
        static T cv<T>(string s) => eq<T, int>() ? ct<T, int>(int.Parse(s))
                           : eq<T, long>() ? ct<T, long>(long.Parse(s))
                           : eq<T, double>() ? ct<T, double>(double.Parse(s))
                           : eq<T, char>() ? ct<T, char>(s[0])
                                             : ct<T, string>(s);
        static void Multi<T>(out T a) => a = cv<T>(GetStr());
        static void Multi<T, U>(out T a, out U b)
        {
            var ar = GetStrArray(); a = cv<T>(ar[0]); b = cv<U>(ar[1]);
        }
        static void Multi<T, U, V>(out T a, out U b, out V c)
        {
            var ar = GetStrArray(); a = cv<T>(ar[0]); b = cv<U>(ar[1]); c = cv<V>(ar[2]);
        }
        static void Multi<T, U, V, W>(out T a, out U b, out V c, out W d)
        {
            var ar = GetStrArray(); a = cv<T>(ar[0]); b = cv<U>(ar[1]); c = cv<V>(ar[2]); d = cv<W>(ar[3]);
        }
        static void Multi<T, U, V, W, X>(out T a, out U b, out V c, out W d, out X e)
        {
            var ar = GetStrArray(); a = cv<T>(ar[0]); b = cv<U>(ar[1]); c = cv<V>(ar[2]); d = cv<W>(ar[3]); e = cv<X>(ar[4]);
        }
        static void Multi<T, U, V, W, X, Y>(out T a, out U b, out V c, out W d, out X e, out Y f)
        {
            var ar = GetStrArray(); a = cv<T>(ar[0]); b = cv<U>(ar[1]); c = cv<V>(ar[2]); d = cv<W>(ar[3]); e = cv<X>(ar[4]); f = cv<Y>(ar[5]);
        }
    }
}
