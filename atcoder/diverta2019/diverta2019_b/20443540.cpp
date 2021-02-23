// detail: https://atcoder.jp/contests/diverta2019/submissions/20443540
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int r, g, b, n;
  cin >> r >> g >> b >> n;
  int res = 0;
  for (int i = 0; r * i <= n; i++) {
    for (int j = 0; r * i + g * j <= n; j++) {
      var remain = n - r * i - g * j;
      if (remain % b == 0) {
        res++;
      }
    }
  }
  cout << res << endl;
}
