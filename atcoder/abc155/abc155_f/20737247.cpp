// detail: https://atcoder.jp/contests/abc155/submissions/20737247
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }
template<typename T> void drop(const T& x) { cout << x << endl; exit(0); }

using P = pair<int, int>;
vector<vector<P>> g;

vector<int> db;

vector<int> res;
vector<bool> arrived;

bool solve(int node) {
  arrived[node] = true;
  for (var&& [adj, ind] : g[node]) {
    if (arrived[adj]) continue;
    if (solve(adj)) {
      db[node] ^= 1;
      res.emplace_back(ind);
    }
  }
  return db[node];
}

int main() {
  int n, m;
  cin >> n >> m;
  vector<P> bombs(n);
  for (int i = 0; i < n; i++) {
    cin >> bombs[i].first;
    cin >> bombs[i].second;
  }
  sort(bombs.begin(), bombs.end());
  vector<int> a;
  for (int i = 0; i < n; i++) a.emplace_back(bombs[i].first);
  a.emplace_back(1e9 + 1);
  db = vector<int>{};
  int prev = 0;
  for (int i = 0; i < n; i++) {
    var cur = bombs[i].second;
    db.emplace_back(prev ^ cur);
    prev = cur;
  }
  db.emplace_back(prev);

  g = vector<vector<P>>(n + 1);
  arrived = vector<bool>(n + 1);
  for (int i = 0; i < m; i++) {
    int l, r;
    cin >> l >> r;
    var lind = lower_bound(a.begin(), a.end(), l) - a.begin();
    var rind = upper_bound(a.begin(), a.end(), r) - a.begin();
    g[lind].emplace_back(rind, i);
    g[rind].emplace_back(lind, i);
  }
  for (int i = 0; i <= n; i++) {
    if (arrived[i]) continue;
    if (solve(i)) drop(-1);
  }
  sort(res.begin(), res.end());
  cout << res.size() << endl;
  for (var&& r : res) cout << r + 1 << ' ';
  cout << endl;
}
