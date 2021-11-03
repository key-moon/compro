// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2585/judge/6026021/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

struct Edge {
  int from;
  int to;
  int cost;
  int time;
  int company;
  Edge(int f, int t, int c, int ti, int co) : from(f), to(t), cost(c), time(ti), company(co){}
};

bool solve() {
  int n, m, h, k;
  cin >> n >> m >> h >> k;
  
  if (n == 0) return false;

  vector<vector<Edge>> g(n);
  
  for (int i = 0; i < m; i++) {
    int s, t, c, h, r;
    cin >> s >> t >> c >> h >> r;
    s--; t--; r--;
    g[s].emplace_back(s, t, c, h, r);
    g[t].emplace_back(t, s, c, h, r);
  }

  int s, t;
  cin >> s >> t;
  s--; t--;

  int p;
  cin >> p;
  // (b, cost)
  vector<pair<int, int>> pairs;
  for (int i = 0; i < p; i++) {
    int l, d;
    cin >> l >> d;
    int b = 0;
    for (int i = 0; i < l; i++) {
      int k;
      cin >> k; k--;
      b |= 1 << k;
    }
    pairs.emplace_back(b, d);
  }

  ll res = LLONG_MAX / 2;
  vector<ll> bits_min_cost(1 << k, LLONG_MAX / 2);
  bits_min_cost[0] = 0;
  for (int b = 0; b < (1 << k); b++) {
    if (LLONG_MAX / 2 <= bits_min_cost[b]) continue;
    vector<vector<ll>> min_cost(h + 1, vector<ll>(n, LLONG_MAX / 2));
    min_cost[0][s] = bits_min_cost[b];

    for (int time = 0; time <= h; time++) {
      for (int cur = 0; cur < n; cur++) {
        var cost = min_cost[time][cur];
        for (var&& edge : g[cur]) {
          var nxt = edge.to;
          var nxt_time = time + edge.time;
          var nxt_cost = cost + ((b >> edge.company & 1) ? 0 : edge.cost);
          if (h < nxt_time) continue;
          chmin(min_cost[nxt_time][nxt], nxt_cost);
        }
      }
      chmin(res, min_cost[time][t]);
    }

    for (var&&[b2, cost] : pairs) {
      chmin(bits_min_cost[b | b2], bits_min_cost[b] + cost);
    }
  }
  if (LLONG_MAX / 2 <= res) res = -1;
  cout << res << endl;
  return true;
}
int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}


