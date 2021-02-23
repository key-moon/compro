// detail: https://atcoder.jp/contests/abc068/submissions/20447152
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, m;
  cin >> n >> m;
  vector<bool> to1(n);
  vector<bool> ton(n);
  for (int i = 0; i < m; i++) {
    int a, b;
    cin >> a >> b;
    if (a > b) swap(a, b);
    a--; b--;
    if (a == 0) to1[b] = true;
    if (b == n - 1) ton[a] = true;
  }
  for (int i = 0; i < n; i++) {
    if (to1[i] && ton[i]) {
      cout << "POSSIBLE" << endl;
      return 0;
    }
  }
  cout << "IMPOSSIBLE" << endl;
}
