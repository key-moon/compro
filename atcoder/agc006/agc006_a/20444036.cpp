// detail: https://atcoder.jp/contests/agc006/submissions/20444036
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  string s, t;
  cin >> n >> s >> t;
  for (int i = 0; i <= n; i++) {
    if (s.substr(i) == t.substr(0, n - i)) {
      cout << n + i << endl;
      return 0;
    }
  }
}
