// detail: https://atcoder.jp/contests/abc055/submissions/20440413
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  int n;
  cin >> n;
  ll res = 1;
  for (int i = 1; i <= n; i++) {
    res *= i;
    res %= MOD;
  }
  cout << res << endl;
}
