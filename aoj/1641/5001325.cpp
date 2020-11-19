// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1641/judge/5001325/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int m, n, p;
  while (cin >> m >> n >> p, m){
    vector<bool> dp(m + 1);
    dp[p] = true;
    for (int i = 0; i < n; i++){
      int a, b;
      cin >> a >> b;
      dp[a] = dp[a] | dp[b];
      dp[b] = dp[b] | dp[a];
    }
    int cnt = 0;
    for (var&& elem : dp){
      if (elem) cnt++;
    }
    cout << cnt << endl;
  }
  return 0;
}
