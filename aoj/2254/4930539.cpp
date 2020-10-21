// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2254/judge/4930539/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  int n;
  cin >> n;
  if (n == 0) return 0;
  vector<int> initts(n);
  vector<vector<int>> ts(n, vector<int>(n + 1));
  for (int i = 0; i < n; i++){
    int init;
    cin >> init;
    initts[i] = init;
    for (int j = 0; j < n; j++){
      int t;
      cin >> t;
      chmin(t, init);
      ts[i][j] = t;
    }
  }
  
  vector<int> dp(1 << n, INT_MAX / 2);
  for (int i = 0; i < n; i++){
    dp[1 << i] = initts[i];
  }
  for (int i = 1; i < (1 << n); i++){
    for (int j = 0; j < n; j++){
      if (i >> j & 1) continue;
      for (int k = 0; k < n; k++){
        if (!(i >> k & 1)) continue;
        chmin(dp[i | (1 << j)], dp[i] + ts[j][k]);
      }
    }
  }
  cout << dp.back() << endl;
  main();
}

