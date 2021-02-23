// detail: https://atcoder.jp/contests/abc115/submissions/20439274
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, k;
  cin >> n >> k;
  vector<int> h(n);
  for (int i = 0; i < n; i++) cin >> h[i];
  sort(h.begin(), h.end());
  int res = INT_MAX;
  for (int i = 0; i + k <= n; i++) {
    chmin(res ,h[i + k - 1] - h[i]);
  }
  cout << res << endl;
}
