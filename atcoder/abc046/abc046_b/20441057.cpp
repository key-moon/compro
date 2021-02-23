// detail: https://atcoder.jp/contests/abc046/submissions/20441057
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  int n, k;
  cin >> n >> k;
  ll res = k;
  for (int i = 1; i < n; i++) {
    res *= k - 1;
  }
  cout << res << endl;
}
