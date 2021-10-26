// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2709/judge/6000701/C++17
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
  int n, m, k;
  cin >> n >> m >> k;
  vector<int> d(m);
  for (var&& item : d) {
    cin >> item;
    item--;
  }
  vector<vector<int>> vs(n, vector<int>(k));
  for (var&& v : vs) {
    for (var&& elem : v) {
      cin >> elem;
      elem--;
    }
  }

  vector<int> rev_d(n, -1);
  for (int i = 0; i < d.size(); i++) {
    rev_d[d[i]] = i;
  }

  vector<int> dist(1 << m, INT_MAX / 2);
  queue<int> q{};
  dist.back() = 0;
  q.push(dist.size() - 1);
  while (not q.empty()) {
    var b = q.front(); q.pop();

    for (int road = 0; road < k; road++) {
      int nxt_b = 0;
      for (int i = 0; i < m; i++) {
        if (!(b >> i & 1)) continue;
        var nxt = rev_d[vs[d[i]][road]];
        if (nxt == -1) continue;
        nxt_b |= 1 << nxt;
      }
      if (dist[nxt_b] <= dist[b] + 1) continue;
      dist[nxt_b] = dist[b] + 1;
      q.push(nxt_b);
    }
  }
  cout << dist.front() << endl;
}

