// detail: https://atcoder.jp/contests/arc116/submissions/21358041
#include<bits/stdc++.h>
#include<atcoder/all>

#pragma GCC target("avx2")
#pragma GCC optimize("O3")
#pragma GCC optimize("unroll-loops")

using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;
using namespace atcoder;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using M = modint998244353;

const int MAX = 10000;

M factor[MAX + 1];
M inv_factor[MAX + 1];

void init() {
  factor[0] = 1;
  for (int i = 1; i <= MAX; i++) {
    factor[i] = factor[i - 1] * i;
  }
  inv_factor[MAX] = factor[MAX].inv();
  for (int i = MAX - 1; i >= 0; i--) {
    inv_factor[i] = inv_factor[i + 1] * (i + 1);
  }
}

M comb(int n, int m) {
  return factor[n] * inv_factor[m] * inv_factor[n - m];
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  init();

  int n, m;
  cin >> n >> m;
  vector<M> dp(m + 1);
  dp[0] = 1;
  for (int i = 1; i <= m; i *= 2) {
    for (int j = m; j >= 0; j--) {
      for (int k = j + i * 2, cnt = 2; k <= m; k += (i * 2), cnt += 2) {
        if (n < cnt) break;
        dp[k] += dp[j] * comb(n, cnt);
      }
    }
  }
  cout << dp[m].val() << endl;
}
