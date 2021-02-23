// detail: https://atcoder.jp/contests/agc015/submissions/20443857
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll n, a, b;
  cin >> n >> a >> b;
  if (n == 1) {
    cout << (a == b ? 1 : 0) << endl;
    return 0;
  }
  cout << max((b - a) * (n - 2) + 1, 0LL) << endl;
}
