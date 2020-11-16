// detail: https://codeforces.com/contest/652/submission/98558886
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2> inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

struct TwoEdgeConnectedComponents{
  vector<int> ord,low,par,blg,sz;
  vector<vector<int>> G,C;

  TwoEdgeConnectedComponents(int n):
    ord(n,-1),low(n),par(n,-1),blg(n,-1),sz(n,1),G(n){}

  void add_edge(int u,int v){
    if(u==v) return;
    G[u].emplace_back(v);
    G[v].emplace_back(u);
  }

  bool is_bridge(int u,int v){
    if(ord[u]>ord[v]) swap(u,v);
    return ord[u]<low[v];
  }

  void dfs(int v,int &pos){
    ord[v]=low[v]=pos++;
    int dup=0;
    for(int u:G[v]){
      if(u==par[v] and !dup){
        dup=1;
        continue;
      }
      if(~ord[u]){
        low[v]=min(low[v],ord[u]);
        continue;
      }
      par[u]=v;
      dfs(u,pos);
      sz[v]+=sz[u];
      low[v]=min(low[v],low[u]);
    }
  }

  void fill_component(int v){
    C[blg[v]].emplace_back(v);
    for(int u:G[v]){
      if(~blg[u] or is_bridge(u,v)) continue;
      blg[u]=blg[v];
      fill_component(u);
    }
  }

  void add_component(int v,int &k){
    if(~blg[v]) return;
    blg[v]=k++;
    C.emplace_back();
    fill_component(v);
  }

  int build(){
    int n=G.size(),pos=0;
    for(int i=0;i<n;i++)
      if(ord[i]<0) dfs(i,pos);

    int k=0;
    for(int i=0;i<n;i++) add_component(i,k);

    return k;
  }

  const vector<int>& operator[](int i)const{return C[i];}

  vector<vector<int>> forest(){
    int n=G.size(),k=C.size();
    vector<vector<int>> T(k);
    for(int v=0;v<n;v++)
      for(int u:G[v])
        if(blg[v]!=blg[u])
          T[blg[v]].emplace_back(blg[u]);
    return T;
  }
};

signed main(){
  cin.tie(0);
  ios::sync_with_stdio(0);

  int n,m;
  cin>>n>>m;

  using P = pair<int, int>;
  vector<P> ps{};
  TwoEdgeConnectedComponents C(n);
  for(int i=0;i<m;i++){
    int a,b,c;
    cin>>a>>b>>c;
    a--, b--;
    C.add_edge(a,b);
    if (c) ps.emplace_back(a, b);
  }
  int p, q;
  cin >> p >> q;
  p--, q--;

  int k=C.build();
  set<P> hastreasure{};
  for (var&& [a, b]: ps){
    hastreasure.emplace(C.blg[a], C.blg[b]);
    hastreasure.emplace(C.blg[b], C.blg[a]);
  }
  
  vector<int> last(n, -2);
  stack<int> st{};
  last[p] = -1;
  st.push(p);
  while (!st.empty()){
    var cur = st.top(); st.pop();
    for (var&& adj : C.G[cur]){
      if (last[adj] != -2) continue;
      last[adj] = cur;
      st.push(adj);
    }
  }
  int lastcomp = C.blg[q];
  var curpos = q;
  bool res = hastreasure.count(P(lastcomp, lastcomp)) != 0;
  while (curpos != -1){
    var curcomp = C.blg[curpos];
    if (curcomp != lastcomp){
      res |= hastreasure.count(P(lastcomp, curcomp)) != 0;
      res |= hastreasure.count(P(curcomp, curcomp)) != 0;
      lastcomp = curcomp;
    }
    curpos = last[curpos];
  }
  cout << (res ? "YES" : "NO") << endl;

  return 0;
}
