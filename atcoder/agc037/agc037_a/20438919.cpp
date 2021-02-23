// detail: https://atcoder.jp/contests/agc037/submissions/20438919
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  int n = s.size();
  s += "$$$$";
  using P = pair<int, int>;
  vector<P> dp(n + 4, P(INT_MIN / 2, INT_MIN / 2));
  dp[0].first = 1;
  dp[1].second = 1;
  for (int i = 0; i < n; i++) {
    if (s[i] != s[i + 1]) {
      chmax(dp[i + 1].first, dp[i].first + 1);
    }
    chmax(dp[i + 1].first, dp[i].second + 1);
    chmax(dp[i + 2].second, dp[i].first + 1);
    chmax(dp[i + 2].second, dp[i].second + 1);
  }
  cout << max(dp[n - 1].first, dp[n - 1].second) << endl;
}
