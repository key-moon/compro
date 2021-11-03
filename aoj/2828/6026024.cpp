// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2828/judge/6026024/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

struct Box {
  int x;
  int y;
  int z;

  Box(int x, int y, int z) : x(x), y(y), z(z){}

  ll volume() { return x * y * z; }

  vector<Box> rotates() {
    vector<Box> v{
      Box(x, y, z),
      Box(x, z, y),
      Box(y, x, z),
      Box(y, z, x),
      Box(z, x, y),
      Box(z, y, x)
    };
    return v;
  }

  bool contains(Box& inner) {
    for (var&& b : rotates()) {
      if (inner.x < b.x && inner.y < b.y && inner.z < b.z) return true;
    }
    return false;
  }
};

// O(F E \log V)
template<typename Flow, typename Cost>
struct PrimalDual {
  struct Edge {
    int dst;
    Flow cap;
    Cost cost;
    int rev;
    Edge(int dst, Flow cap, Cost cost, int rev) :
      dst(dst), cap(cap), cost(cost), rev(rev) {}
  };

  vector<vector<Edge>> G;
  vector<Cost> h, dist;
  vector<int> prevv, preve;

  PrimalDual(int n) :G(n), h(n), dist(n), prevv(n), preve(n) {}

  void add_edge(int u, int v, Flow cap, Cost cost) {
    int e = G[u].size();
    int r = (u == v ? e + 1 : G[v].size());
    G[u].emplace_back(v, cap, cost, r);
    G[v].emplace_back(u, 0, -cost, e);
  }

  Cost residual_cost(int src, Edge& e) {
    return e.cost + h[src] - h[e.dst];
  }

  void dijkstra(int s) {
    struct P {
      Cost first;
      int second;
      P(Cost first, int second) :first(first), second(second) {}
      bool operator<(const P& a) const { return first > a.first; }
    };
    priority_queue<P> pq;

    dist[s] = 0;
    pq.emplace(dist[s], s);
    while (!pq.empty()) {
      P p = pq.top(); pq.pop();
      int v = p.second;
      if (dist[v] < p.first) continue;
      for (int i = 0; i < (int)G[v].size(); i++) {
        Edge& e = G[v][i];
        if (e.cap == 0) continue;
        if (!(dist[v] + residual_cost(v, e) < dist[e.dst])) continue;
        dist[e.dst] = dist[v] + e.cost + h[v] - h[e.dst];
        prevv[e.dst] = v;
        preve[e.dst] = i;
        pq.emplace(dist[e.dst], e.dst);
      }
    }
  }

  Cost res;

  bool build(int s, int t, Flow f) {
    res = 0;
    [](decltype(h)& p) {
      fill(p.begin(), p.end(), 0);
    }(h);
    const Cost INF = numeric_limits<Cost>::max();
    while (f > 0) {
      fill(dist.begin(), dist.end(), INF);
      dijkstra(s);
      if (dist[t] == INF) return false;

      for (int v = 0; v < (int)h.size(); v++)
        if (dist[v] < INF) h[v] = h[v] + dist[v];

      Flow d = f;
      for (int v = t; v != s; v = prevv[v])
        d = min(d, G[prevv[v]][preve[v]].cap);

      f -= d;
      res = res + h[t] * d;
      for (int v = t; v != s; v = prevv[v]) {
        Edge& e = G[prevv[v]][preve[v]];
        e.cap -= d;
        G[v][e.rev].cap += d;
      }
    }
    return true;
  }

  Cost get_cost() { return res; }
};

bool solve() {
  int n;
  cin >> n;
  if (n == 0) return false;

  vector<Box> boxes(n, Box(0, 0, 0));
  for (var&& box : boxes) {
    cin >> box.x >> box.y >> box.z;
  }

  int s, t;
  s = 3 * n; t = s + 1;
  PrimalDual<int, int> mcf(t + 1);
  for (int i = 0; i < n; i++) {
    var vol_i = boxes[i].volume();
    for (int j = 0; j < n; j++) {
      if (not boxes[i].contains(boxes[j])) continue;
      var vol_j = boxes[j].volume();
      assert(vol_i > vol_j);
      mcf.add_edge(i, n + j, 1, vol_i - vol_j);
    }
    mcf.add_edge(i, n + n + i, 1, vol_i);

    mcf.add_edge(s, i, 1, 0);
    mcf.add_edge(n + i, t, 1, 0);
    mcf.add_edge(n + n + i, t, 1, 0);
  }
  mcf.build(s, t, 1e9);
  cout << mcf.get_cost() << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}


