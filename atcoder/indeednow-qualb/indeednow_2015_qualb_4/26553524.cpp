// detail: https://atcoder.jp/contests/indeednow-qualb/submissions/26553524
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
  ll n, c;
  cin >> n >> c;
  vector<int> a(n);
  vector<vector<int>> poses(c, vector<int>{-1});
  for (var i = 0; i < n; i++) {
    cin >> a[i]; a[i]--;
    poses[a[i]].emplace_back(i);
  }
  for (var i = 0; i < c; i++) {
    poses[i].emplace_back(n);
    ll res = n * (n + 1) / 2;
    for (int j = 1; j < poses[i].size(); j++) {
      ll gap = poses[i][j] - poses[i][j - 1];
      res -= gap * (gap - 1) / 2;
    }
    cout << res << newl;
  }
}
