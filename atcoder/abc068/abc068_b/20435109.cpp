// detail: https://atcoder.jp/contests/abc068/submissions/20435109
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  int res = 1;
  while (res <= n) res *= 2;
  res /= 2;
  cout << res << endl;
}
