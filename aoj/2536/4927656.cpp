// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2536/judge/4927656/C++17
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if (a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if (a < b) a = b; }

struct UnionFind{
  int num;
  vector<int> rs,ps;
  UnionFind(){}
  UnionFind(int n):num(n),rs(n,1),ps(n,0){iota(ps.begin(),ps.end(),0);}
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

int main(){
  cin.tie(nullptr);
  ios::sync_with_stdio(false);
  //入
  int n, m;
  cin >> n >> m;
  if (n == 0) return 0;
  using P = pair<int, int>;
  using PP = pair<int, P>;
  vector<PP> g{};
  for (int i = 0; i < m; i++){
    int s, t, c;
    cin >> s >> t >> c;
    s--; t--;
    g.emplace_back(c, P(s, t));
  }
  sort(g.begin(), g.end());
  //中央値決め打ち二分探索
  int valid = m, invalid = -1;
  //まず中央値を決めて、その上でそれ以下のやつで全部繋ぐ
  //残りを適当に繋いで、使った本数が
  //辺はn-1本
  //だからn/2-1本より上だったらヤバ
  while (valid - invalid > 1){
    var mid = (valid + invalid) / 2;
    UnionFind uf(n);
    for (int i = 0; i <= mid; i++) {
      var [s, t] = g[i].second;
      uf.unite(s, t);
    }
    int ctr = 0;
    for (int i = mid + 1; i < m; i++){
      var [s, t] = g[i].second;
      if (uf.same(s, t)) continue;
      uf.unite(s, t);
      ctr++;
    }
    if (ctr <= n / 2 - 1) valid = mid;
    else invalid = mid;
  }
  cout << g[valid].first << endl;
  main();
}

