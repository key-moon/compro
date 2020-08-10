// detail: https://atcoder.jp/contests/agc047/submissions/15800421
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
            //gen 1
            var xptr = 0;
            var yptr = 1;
            var resptr = 2;

            var zeroPtr = 99999;
            var onePtr = 3;

            ulong[] arr = new ulong[200000];
            arr[xptr] = (ulong)a;
            arr[yptr] = (ulong)b;

            void CompAssign(int i, int j, int k) { arr[k] = arr[i] < arr[j] ? 1UL : 0UL; seq.Add($"< {i} {j} {k}"); }
            void AddAssign(int i, int j, int k) { arr[k] = arr[i] + arr[j]; seq.Add($"+ {i} {j} {k}"); }

            AddAssign(xptr, yptr, onePtr);

            void Add(int ptr, int adder) => AddAssign(ptr, adder, ptr);
            void Incr(int ptr) => Add(ptr, onePtr);
            void SetZero(int ptr) => CompAssign(zeroPtr, zeroPtr, ptr);
            void SetOne(int ptr) => CompAssign(zeroPtr, onePtr, ptr);
            void Assign(int srcPtr, int destPtr)
            {
                SetZero(destPtr);
                AddAssign(srcPtr, destPtr, destPtr);
            }
            SetOne(onePtr);

            //Gen Pow
            var powOffset = 1000;
            int PowPtr(int num) => powOffset + num;
            AddAssign(onePtr, zeroPtr, PowPtr(0));
            for (int i = 0; i <= 50; i++)
                AddAssign(PowPtr(i), PowPtr(i), PowPtr(i + 1));
            
            void PowNum(int ptr, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    AddAssign(ptr, ptr, ptr);
                }
            }

            void ZeroOrNum(int numPtr, int zeroFlagPtr, int destPtr)
            {
                var _numPtr = 2010;
                AddAssign(numPtr, onePtr, _numPtr);
                var ctrPtr = 2000;
                Assign(zeroPtr, ctrPtr);
                Assign(zeroPtr, destPtr);
                //flagを増殖
                for (int i = 31; i >= 0; i--)
                {
                    var flagPtr = 2001;
                    var testPtr = 2002;
                    Assign(ctrPtr, testPtr);
                    AddAssign(testPtr, PowPtr(i), testPtr);

                    //a < b, flagにnumのibit目が0かの成否が入る
                    CompAssign(testPtr, _numPtr, flagPtr);

                    var toPowPtr = 2004;
                    AddAssign(flagPtr, zeroFlagPtr, toPowPtr);
                    CompAssign(onePtr, toPowPtr, toPowPtr);

                    PowNum(toPowPtr, i);
                    AddAssign(destPtr, toPowPtr, destPtr);

                    //ctrPtrに足して調節
                    {
                        var powedPtr = 2003;
                        Assign(flagPtr, powedPtr);
                        PowNum(powedPtr, i);
                        AddAssign(ctrPtr, powedPtr, ctrPtr);
                    }
                }
            }

            void MulNum(int aPtr, int bPtr, int destPtr)
            {
                //bの各bitについて、aを増殖させる
                //増殖方法:
                //  bのbitが1→a
                //   　   　0→0
                //  をレジスタに入れて、
                //  bの各bitの量だけ繰り返し二乗みたいにする
                //bのbitがどうかを判断する方法:
                //  まず

                var ctrPtr = 3000;
                Assign(zeroPtr, ctrPtr);
                var _bPtr = 3010;
                AddAssign(bPtr, onePtr, _bPtr);
                for (int i = 31; i >= 0; i--)
                {
                    var flagPtr = 3002;
                    var testPtr = 3001;
                    Assign(ctrPtr, testPtr);
                    AddAssign(testPtr, PowPtr(i), testPtr);

                    //a < b, flagにbのibit目が0かの成否が入る
                    CompAssign(testPtr, _bPtr, flagPtr);

                    //curMulPtrに0か(2^i)*aが入る
                    var curMulPtr = 3004;
                    ZeroOrNum(aPtr, flagPtr, curMulPtr);
                    PowNum(curMulPtr, i);

                    AddAssign(destPtr, curMulPtr, destPtr);

                    //ctrPtrに足して調節
                    {
                        var powedPtr = 3003;
                        Assign(flagPtr, powedPtr);
                        PowNum(powedPtr, i);
                        AddAssign(ctrPtr, powedPtr, ctrPtr);
                    }
                }
            }

            MulNum(xptr, yptr, resptr);

            if (a * b != arr[resptr]) throw new Exception();

            return $"{seq.Count}\n{string.Join(" ", seq)}";
        }
    }
}
