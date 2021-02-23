// detail: https://atcoder.jp/contests/abc087/submissions/20436299
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int a, b, c, x;
  cin >> a >> b >> c >> x;
  int res = 0;
  for (int i = 0; i <= a; i++) {
    for (int j = 0; j <= b; j++) {
      for (int k = 0; k <= c; k++) {
        if (i * 500 + j * 100 + k * 50 == x) res++;
      }
    }
  }
  cout << res << endl;
}
