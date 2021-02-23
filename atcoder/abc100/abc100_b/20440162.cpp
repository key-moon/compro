// detail: https://atcoder.jp/contests/abc100/submissions/20440162
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int d, n;
  cin >> d >> n;
  int mul;
  if (d == 0) mul = 1;
  if (d == 1) mul = 100;
  if (d == 2) mul = 10000;
  int cnt = 0;
  int cur = 0;
  while (cnt < n) {
    cur++;
    while (cur % 100 == 0) cur++;
    cnt++;
  }
  cout << mul * cur << endl;
}
