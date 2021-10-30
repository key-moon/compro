// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1612/judge/6015570/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const ll inf = INT32_MAX;

struct Box;
bool ow(Box a, Box b);

ll w;

struct Box {
  ll x, y, z;
  ll s() {
    return w * w * 6;
  }
  ll eats(Box& a) {
    if (not ow(*this, a)) return 0;
    var dx = w - abs(x - a.x);
    var dy = w - abs(y - a.y);
    var dz = w - abs(z - a.z);
    assert(dx <= w && dy <= w && dz <= w);
    ll res = 0;
    return (dx * dy + dy * dz + dz * dx) * 2;
  }
};

bool ow(Box a, Box b) {
  ll maxdist = 0;
  chmax(maxdist, abs(a.x - b.x));
  chmax(maxdist, abs(a.y - b.y));
  chmax(maxdist, abs(a.z - b.z));
  assert(maxdist != w);
  return maxdist < w;
}

struct Boxes {
  ll s = 0;
  deque<Box> q;
  Box prev2;
  Box prev1;

  void check() {
    ll res = 0;
    for (int i = 0; i < q.size(); i++) {
       res += q[i].s();
       if (i == 0) continue;
       res -= q[i].eats(q[i - 1]);
    }
    if (res != s) {
      cout << "";
    }
    assert(res == s);
  }

  void push(Box cur) {
    check();
    if (q.size() != 0) {
      s -= cur.eats(q.back());
    }
    s += cur.s();
    q.emplace_back(cur);
  }
  void pop() {
    check();
    assert(!q.empty());
    var popped = q.front(); q.pop_front();
    s -= popped.s();
    if (q.size() == 0) return;
    s += popped.eats(q.front());
  }
};

struct UnionFind {
  int num;
  vector<int> rs, ps;
  UnionFind(int n) :num(n), rs(n, 1), ps(n, 0) {
    iota(ps.begin(), ps.end(), 0);
  }
  int find(int x) {
    return (x == ps[x] ? x : ps[x] = find(ps[x]));
  }
  bool same(int x, int y) {
    return find(x) == find(y);
  }
  void unite(int x, int y) {
    x = find(x); y = find(y);
    if (x == y) return;
    if (rs[x] < rs[y]) swap(x, y);
    rs[x] += rs[y];
    ps[y] = x;
    num--;
  }
  int size(int x) {
    return rs[find(x)];
  }
  int count() const {
    return num;
  }
};

bool solve() {
  int n, k;
  cin >> n >> k >> w;
  if (n == 0) return false;
  vector<Box> v(n);
  for (var&& item : v) cin >> item.x >> item.y >> item.z;

  vector<vector<int>> graph(n);
  UnionFind uf(n);
  for (int i = 0; i < n; i++) {
    for (int j = i + 1; j < n; j++) {
      if (ow(v[i], v[j])) {
        uf.unite(i, j);
        graph[i].emplace_back(j);
        graph[j].emplace_back(i);
      }
    }
  }


  const ll inf = LLONG_MAX;
  ll res = inf;

  for (int id = 0; id < n; id++) {
    bool has_point = false;
    int first = -1;
    for (int i = 0; i < n; i++) {
      if (uf.find(i) != id) continue;
      if (graph[i].size() == 1) {
        if (not has_point) {
          first = i;
        }
        has_point = true;
        continue;
      }
      if (not has_point) {
        first = i;
      }
    }

    if (first == -1) continue;
    if (uf.size(first) < k) continue;

    int last = -1;
    int cur = first;
    Boxes b; b.push(v[cur]);

    while (b.q.size() < k) {
      for (var&& adj : graph[cur]) {
        if (adj == last) continue;
        b.push(v[adj]);
        last = cur;
        cur = adj;
        break;
      }
    }

    assert(b.q.size() == k);

    if (k != 1 && uf.size(first) == k && not has_point) {
      b.s -= b.q.front().eats(b.q.back());
      chmin(res, b.s);
      continue;
    }

    ll curres = b.s;

    int cnt = has_point ? (uf.size(first) - k) : (uf.size(first) - 1);
    for (int _ = 0; _ < cnt; _++) {
      b.pop();
      for (var&& adj : graph[cur]) {
        if (adj == last) continue;
        b.push(v[adj]);
        last = cur;
        cur = adj;
        break;
      }
      assert(b.q.size() == k);
      chmin(curres, b.s);
    }

    chmin(res, curres);
  }
  if (res == inf) res = -1;
  cout << res << endl;
  return true;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}


