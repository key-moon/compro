// detail: https://atcoder.jp/contests/abc063/submissions/20442379
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
  bool possible[10001] = {};
  possible[0] = true;
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    for (int j = 10000 - a; j >= 0; j--) {
      possible[j + a] |= possible[j];
    }
  }
  for (int j = 10000; j >= 0; j--) {
    if (!possible[j] || j % 10 == 0) continue;
    cout << j << endl;
    return 0;
  }
  cout << 0 << endl;
}
