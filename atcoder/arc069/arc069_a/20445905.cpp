// detail: https://atcoder.jp/contests/arc069/submissions/20445905
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n, m;
  cin >> n >> m;
  ll res = 0;
  var pure = min(n, m / 2);
  res += pure;
  n -= pure;
  m -= pure * 2;
  res += m / 4;
  cout << res << endl;
}
