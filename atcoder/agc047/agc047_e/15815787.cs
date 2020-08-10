// detail: https://atcoder.jp/contests/agc047/submissions/15815787
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
        Solve(1, 1);
        Solve(0, 0);
        Solve(1000000000, 0);
        Solve(0, 1000000000);
        Console.WriteLine(Solve(0, 0));
    }

    public static string Solve(ulong a, ulong b)
    {
        checked
        {
            List<string> seq = new List<string>();

            var xptr = 0;
            var yptr = 1;
            var resptr = 2;

            //1とし用いる
            var onePtr = 3;

            //yに近づけていくカウンタ
            var ctrPtr1 = 4;
            //yの今の桁が1かを計算するためのアドレス
            var tmpAndFlagPtr1 = 5;

            //0かxを入れる処理の結果が入る
            var tmpResPtr = 6;

            //xに近づけていくカウンタ
            var ctrPtr2 = 7;
            //xの今の桁が1かを計算するためのアドレス
            var tmpAndFlagPtr2 = 8;

            //計算用に2^iを入れる等、本当に一瞬だけ使うためのアドレス
            var volatilePtr = 9;

            //0として用いる
            var zeroPtr = 10;

            ulong[] arr = new ulong[200000];
            arr[xptr] = a;
            arr[yptr] = b;

            void CompAssign(int i, int j, int k) { arr[k] = arr[i] < arr[j] ? 1UL : 0UL; seq.Add($"< {i} {j} {k}"); }
            void AddAssign(int i, int j, int k) { arr[k] = arr[i] + arr[j]; seq.Add($"+ {i} {j} {k}"); }

            AddAssign(xptr, yptr, onePtr);

            void SetZero(int ptr) => CompAssign(ptr, ptr, ptr);
            void SetOne(int ptr) => CompAssign(zeroPtr, onePtr, ptr);
            void Assign(int srcPtr, int destPtr)
            {
                SetZero(destPtr);
                AddAssign(srcPtr, destPtr, destPtr);
            }
            SetOne(onePtr);

            AddAssign(xptr, onePtr, xptr);
            AddAssign(yptr, onePtr, yptr);

            void PowNum(int ptr, int count)
            {
                for (int i = 0; i < count; i++) AddAssign(ptr, ptr, ptr);
            }

            int PowPtr(int count)
            {
                SetOne(volatilePtr);
                PowNum(volatilePtr, count);
                return volatilePtr;
            }


            //yの各bitについて、xを掛けてresに足す
            SetZero(ctrPtr1);
            for (int i = 31; i >= 0; i--)
            {
                Assign(ctrPtr1, tmpAndFlagPtr1);
                AddAssign(tmpAndFlagPtr1, PowPtr(i), tmpAndFlagPtr1);

                //a < b, flagにyのibit目が0かの成否が入る
                CompAssign(tmpAndFlagPtr1, yptr, tmpAndFlagPtr1);

                //tmpResPtrにflagPtr1に応じて0かxが入る
                {
                    SetZero(ctrPtr2);
                    SetZero(tmpResPtr);
                    //flagを増殖
                    for (int j = 31; j >= 0; j--)
                    {
                        Assign(ctrPtr2, tmpAndFlagPtr2);
                        AddAssign(tmpAndFlagPtr2, PowPtr(j), tmpAndFlagPtr2);

                        //a < b, flagにxのjbit目が0かの成否が入る
                        CompAssign(tmpAndFlagPtr2, xptr, tmpAndFlagPtr2);

                        AddAssign(tmpAndFlagPtr2, tmpAndFlagPtr1, volatilePtr);
                        CompAssign(onePtr, volatilePtr, volatilePtr);

                        PowNum(volatilePtr, j);
                        AddAssign(tmpResPtr, volatilePtr, tmpResPtr);

                        //ctrPtrに足して調節
                        {
                            PowNum(tmpAndFlagPtr2, j);
                            AddAssign(ctrPtr2, tmpAndFlagPtr2, ctrPtr2);
                        }
                    }
                }
                //tmpResPtrを(2^i)倍する
                PowNum(tmpResPtr, i);

                AddAssign(resptr, tmpResPtr, resptr);

                //ctrPtrに足して調節
                PowNum(tmpAndFlagPtr1, i);
                AddAssign(ctrPtr1, tmpAndFlagPtr1, ctrPtr1);
            }

            if (a * b != arr[resptr]) throw new Exception();

            return $"{seq.Count}\n{string.Join("\n", seq)}";
        }
    }
}
