// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2511/judge/4970726/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

//BEGIN CUT HERE
struct UnionFind{
  int num;
  vector<int> rs,ps;
  UnionFind(int n):num(n),rs(n,1),ps(n,0){
    iota(ps.begin(),ps.end(),0);
  }
  int find(int x){
    return (x==ps[x]?x:ps[x]=find(ps[x]));
  }
  bool same(int x,int y){
    return find(x)==find(y);
  }
  void unite(int x,int y){
    x=find(x);y=find(y);
    if(x==y) return;
    if(rs[x]<rs[y]) swap(x,y);
    rs[x]+=rs[y];
    ps[y]=x;
    num--;
  }
  int size(int x){
    return rs[find(x)];
  }
  int count() const{
    return num;
  }
};
//END CUT HERE

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n, m;
  while (cin >> n >> m, n){    
    vector<int> h(n);
    for (int i = 0; i < n; i++) cin >> h[i];
    using P = pair<int, int>;
    using PP = pair<P, int>;

    vector<PP> edges{};
    for (int i = 0; i < m; i++){
      int a, b, c;
      cin >> a >> b >> c;
      a--, b--;
      edges.emplace_back(P(a, b), c);
    }

    sort(edges.begin(), edges.end(), [](PP a, PP b){
      return a.second < b.second;
    });

    map<int, vector<int>> mp{};
    for (int i = 0; i < n; i++) mp[h[i]].emplace_back(i);

    vector<int> keys = h;
    sort(keys.begin(), keys.end());
    keys.erase(unique(keys.begin(), keys.end()), keys.end());


    var maxpos = mp[keys.back()].front();
    int deadh;
    for (int i = 0; i < keys.size(); i++){
      UnionFind uf(n);
      for (var&& edge : edges){
        var [st, c] = edge;
        var [s, t] = st;
        if (h[s] <= keys[i] || h[t] <= keys[i]) continue;
        uf.unite(s, t);
      }
      int cnt = 0;
      for (int j = 0; j < n; j++){
        if (h[j] <= keys[i]) continue;
        cnt++;
      }
      var sz = uf.size(maxpos);
      if (sz != cnt){
        deadh = i;
        break;
      }
    }

    ll res = 0;
    {
      UnionFind uf(n);
      for (int i = deadh; i >= 0; i--){
        for (var&& edge : edges){
          var [st, c] = edge;
          var [s, t] = st;
          if (h[s] < keys[i] || h[t] < keys[i]) continue;
          if (uf.same(s, t)) continue;
          uf.unite(s, t);
          res += c;
        }
      }
      if (uf.num != 1) res = 0;
    }
    cout << res << endl;
  }
  return 0;
}

