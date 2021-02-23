// detail: https://atcoder.jp/contests/abc086/submissions/20442104
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
  int prevt = 0;
  int prevy = 0;
  int prevx = 0;
  for (int i = 0; i < n; i++) {
    int t, x, y;
    cin >> t >> x >> y;
    var dt = t - prevt;
    var dx = abs(x - prevx);
    var dy = abs(y - prevy);
    if ((dx + dy) % 2 != dt % 2) goto invalid;
    if (dt < (dx + dy)) goto invalid;
    prevt = t;
    prevx = x;
    prevy = y;
  }
  cout << "Yes" << endl;
  return 0;
invalid:;
  cout << "No" << endl;
}
