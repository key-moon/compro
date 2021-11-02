// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1176/judge/6023237/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

template<typename F>
struct FixPoint : F {
  FixPoint(F&& f) :F(forward<F>(f)) {}
  template<typename... Args>
  decltype(auto) operator()(Args&&... args) const {
    return F::operator()(*this, forward<Args>(args)...);
  }
};
template<typename F>
inline decltype(auto) MFP(F&& f) {
  return FixPoint<F>{forward<F>(f)};
}

bool solve() {
  int h, w, s;
  cin >> h >> w >> s;
  if (h == 0) return false;

  int sum = 0;

  vector<vector<int>> grid(h, vector<int>(w));
  for (var&& row : grid) {
    for (var&& elem : row) {
      cin >> elem;
      sum += elem;
    }
  }
  vector<vector<int>> accum(h + 1, vector<int>(w + 1));
  for (int i = 1; i <= h; i++) {
    for (int j = 1; j <= w; j++) {
      accum[i][j] = accum[i][j - 1] + accum[i - 1][j] - accum[i - 1][j - 1];
      accum[i][j] += grid[i - 1][j - 1];
    }
  }

  var rectsum = [&](int u, int d, int l, int r) {
    return accum[d][r] - accum[d][l] - accum[u][r] + accum[u][l];
  };

  int min_group_threshold = sum - s;

  var get_cnt = [&](int threshold) {
    vector<vector<vector<vector<int>>>> dp(h + 1, vector<vector<vector<int>>>(h + 1, vector<vector<int>>(w + 1, vector<int>(w + 1, -1))));

    var res = MFP([&](auto solve, int u, int d, int l, int r) {
      if (dp[u][d][l][r] != -1) return dp[u][d][l][r];
      var res = threshold <= rectsum(u, d, l, r) ? 1 : 0;
      for (int i = u + 1; i < d; i++) {
        var a = solve(u, i, l, r);
        var b = solve(i, d, l, r);
        if (a == 0 || b == 0) continue;
        chmax(res, a + b);
      }
      for (int i = l + 1; i < r; i++) {
        var a = solve(u, d, l, i);
        var b = solve(u, d, i, r);
        if (a == 0 || b == 0) continue;
        chmax(res, a + b);
      }

      dp[u][d][l][r] = res;
      return res;
      })(0, h, 0, w);


      return res;
  };

  var group_cnt = get_cnt(min_group_threshold);
  int valid = min_group_threshold;
  int invalid = sum + 1;
  while (invalid - valid > 1) {
    var mid = (invalid + valid) / 2;
    if (get_cnt(mid) == group_cnt) valid = mid;
    else invalid = mid;
  }

  cout << group_cnt << " " << valid - min_group_threshold << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}

