// detail: https://codeforces.com/contest/1609/submission/137246526
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

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

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  
  int n, d;
  cin >> n >> d;

  UnionFind uf(n);

  int cnt = 1;
  for (int i = 0; i < d; i++) {
    int a, b;
    cin >> a >> b; a--; b--;
    if (uf.same(a, b)) {
      cnt++;
    }
    uf.unite(a, b);
    
    vector<int> sizes{};
    for (int j = 0; j < n; j++) {
      if (uf.find(j) != j) continue;
      sizes.emplace_back(uf.size(j));
    }
    ll res = 0;
    sort(sizes.begin(), sizes.end());
    for (int i = sizes.size() - 1; sizes.size() <= i + cnt; i--) {
      res += sizes[i];
    }
    cout << res - 1 << endl;
  }
}