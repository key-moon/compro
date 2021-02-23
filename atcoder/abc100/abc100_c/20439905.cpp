// detail: https://atcoder.jp/contests/abc100/submissions/20439905
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
  ll res = 0;
  for (int i = 0; i < n; i++) {
    ll a;
    cin >> a;
    while (!(a & 1)) {
      res++;
      a /= 2;
    }
  }
  cout << res << endl;
}
