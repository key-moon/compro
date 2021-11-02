// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1175/judge/6023111/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

bool solve() {
  int n;
  cin >> n;
  if (n == 0) return false;
  vector<vector<int>> circles;
  vector<vector<int>> dependency(n, vector<int>{});
  for (int i = 0; i < n; i++) {
    vector<int> circle(4);
    cin >> circle[0] >> circle[1] >> circle[2] >> circle[3];
    for (int j = 0; j < i; j++) {
      var prev = circles[j];
      var dx = abs(prev[0] - circle[0]);
      var dy = abs(prev[1] - circle[1]);
      var r = prev[2] + circle[2];
      if (dx * dx + dy * dy < r * r) {
        dependency[i].emplace_back(j);
      }
    }
    circles.emplace_back(circle);
  }

  int res = 0;
  vector<bool> valid(1 << n);
  valid.back() = true;
  for (int b = (1 << n) - 1; b >= 0; b--) {
    if (not valid[b]) continue;
    vector<vector<int>> poses(4);
    int curres = 0;
    for (int i = 0; i < n; i++) {
      if (not (b >> i & 1)) {
        curres++;
        continue;
      }
      for (var&& depend : dependency[i]) {
        if (b >> depend & 1) goto end;
      }
      poses[circles[i][3] - 1].emplace_back(i);
    end:;
    }
    for (var&& p : poses) {
      for (int i = 0; i < p.size(); i++) {
        for (int j = 0; j < i; j++) {
          valid[b - (1 << p[i]) - (1 << p[j])] = true;
        }
      }
    }
    chmax(res, curres);
  }
  cout << res << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}
