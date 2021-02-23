// detail: https://atcoder.jp/contests/abc153/submissions/20435933
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll h;
  cin >> h;
  ll res = 1;
  while (res < h) res = res * 2 + 1;
  cout << res << endl;
}
