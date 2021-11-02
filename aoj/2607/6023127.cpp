// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2607/judge/6023127/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  int n, d, x;
  cin >> n >> d >> x;
  vector<int> cur(n);
  for (var&& elem : cur) cin >> elem;
  for (int i = 1; i < d; i++) {
    vector<int> nxt(n);
    for (var&& elem : nxt) cin >> elem;
    vector<int> dp(x + 1);
    for (int i = 0; i < n; i++) {
      var d = nxt[i] - cur[i];
      if (d < 0) continue;
      for (int j = cur[i]; j <= x; j++) {
        chmax(dp[j], dp[j - cur[i]] + d);
      }
    }
    x += dp[x];
    cur = nxt;
  }
  cout << x << endl;
}

